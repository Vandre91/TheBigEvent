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
        public void AddDeco(string _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddDeco",
                    new { UserId = _UserId },
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
