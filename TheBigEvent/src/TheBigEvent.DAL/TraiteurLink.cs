using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class TraiteurLink
    {
        readonly string _connectionString;

        public TraiteurLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Traiteur> GetAlltraiteur()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Traiteur>("Select * From tbe.tTraiteur");
            }
        }
        public void AddTraiteur(string _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddTraiteur",
                    new { UserId = _UserId },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(int _TraiteurId, int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUpdateTraiteur",
                    new { TraiteurId = _TraiteurId, UserId = _UserId },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int _TraiteurId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteTraiteur",
                    new { TraiteurId = _TraiteurId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
