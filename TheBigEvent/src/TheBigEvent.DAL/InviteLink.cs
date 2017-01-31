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
        public void AddInvite(int _select, string _nom, string _mail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                 con.Query("insert into tbe.tInvite (BigSelecteId,Nom,Mail) values (@select,@nom,@mail)",
                    new { select= _select ,nom = _nom, mail= _mail });
            }
        }
        public IEnumerable<Invite> GetCodeById(string _code)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Invite>("select Nom,Mail,BigSelecteId,Code from tbe.tInvite where Code = @code",
                        new { code = _code });
            }
        }
    }
}
