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
        public void AddSalle(int _NbPlace, int _UserId, string _Descriptions, float _Prix, string _Nom)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddSalle",
                    new { Nbplace = _NbPlace, UserId = _UserId, Descriptions = _Descriptions, Prix = _Prix, Nom = _Nom},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Salle> getSalle(int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Salle>("select * from tbe.Salle where UserId = @UserId ;",
                        new
                        {
                            UserId = _UserId
                        });
            }
        }

        public void Update(int _SalleId, string _NbPlace)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUpdateSalle",
                    new { SalleId = _SalleId, Nbplace = _NbPlace },
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
