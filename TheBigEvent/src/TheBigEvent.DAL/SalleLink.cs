using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class SalleLink
    {
        readonly string _connectionString;

        public SalleLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Salle> GetAllSalle()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Salle>("Select * From tbe.Salle");
            }
        }
        public void AddSalle(string _NbPlace, string _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddSalle",
                    new { Nbplace = _NbPlace, UserId = _UserId },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int _SalleId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteSalle",
                    new { SalleId = _SalleId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
