using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class DecoLink
    {
        readonly string _connectionString;

        public DecoLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Deco> GetAllDeco()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Deco>("Select * From tbe.tDeco");
            }
        }

        public Deco getDeco(int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Deco>("select * from tbe.tDeco where UserId = @UserId ;",
                        new
                        {
                            UserId = _UserId
                        })
                    .FirstOrDefault();
            }
        }


        public void AddDeco(int _UserId, string _Descriptions, float _Prix, string _Nom)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddDeco",
                    new { UserId = _UserId, Descriptions = _Descriptions, Prix = _Prix, Nom = _Nom },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(int _DecoId,int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUpdateDeco",
                    new {DecoId= _DecoId, UserId = _UserId},
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int _DecoId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteDeco",
                    new { DecoId = _DecoId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
