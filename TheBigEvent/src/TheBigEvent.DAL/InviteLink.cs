using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class InviteLink
    {
        readonly string _connectionString;

        public InviteLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddInvite(int _select, string _nom, string _mail, string _code)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                 con.Query("insert into tbe.tInvite (BigSelecteId,Nom,Mail,Code) values (@select,@nom,@mail, @code)",
                    new { select= _select ,nom = _nom, mail= _mail, code = _code });
            }
        }
        public IEnumerable<Invite> GetCodeById(string _code)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Invite>("select inviteId,Nom,Mail,BigSelecteId,Code from tbe.tInvite where Code = @code",
                        new { code = _code });
            }
        }
        public IEnumerable<GuestAnswer> GetAllInviteById(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Invite>(@"select i.InviteId, i.Nom, i.Mail, p.PropositionId, p.Date, v.Etat
                                           from tbe.tBigSelecte bs
                                               inner join tbe.tInvite i on i.BigSelecteId = bs.BigSelecteId
                                               inner join tbe.tProposition p on p.BigSelecteId = bs.BigSelecteId
                                               left outer join tbe.tValide v on v.PropositionId = p.PropositionId and v.InviteId = i.InviteId
                                           where bs.BigSelecteId = @id;",
                new { id = _id })
                .GroupBy(i => new { i.InviteId, i.Nom, i.Mail })
                .Select(i => new GuestAnswer
                {
                    GuestId = i.Key.InviteId,
                    Email = i.Key.Mail,
                    Name = i.Key.Nom,
                    Answers = i.Select(a => new Answer { Date = a.Date, State = (AnswerState)a.Etat })
                });
            }
        }
    }
}
