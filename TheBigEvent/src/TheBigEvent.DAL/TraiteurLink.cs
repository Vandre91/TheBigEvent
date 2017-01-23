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
                return con.Query<Traiteur>("Select *, tbe.tUser.Compagny as Compagny, tbe.tUser.City as City From tbe.tTraiteur join tbe.tUser ON tbe.tUser.UserId = tbe.tTraiteur.UserId");
            }
        }


        public Traiteur getTraiteur(int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Traiteur>(
                        "select * from tbe.tTraiteur where UserId = @UserId ;",
                        new { UserId = _UserId })
                    .FirstOrDefault();
            }
        }
        public IEnumerable<Traiteur> GetAlltraiteurByEvent(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Traiteur>("select NomEvent,tbe.tEvent.UserId,tbe.tEvent.TraiteurId,tbe.tTraiteur.UserId,tbe.tUser.Compagny from tbe.tEvent INNER JOIN tbe.tTraiteur ON tbe.tEvent.TraiteurId = tbe.tTraiteur.TraiteurId INNER JOIN tbe.tUser ON tbe.tTraiteur.UserId = tbe.tUser.UserId where tbe.tEvent.UserId = @Id",
                        new { Id = _id });
            }
        }


        public void AddTraiteur(int _UserId, string _Descriptions, string _Nom)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddTraiteur",
                    new { UserId = _UserId, Descriptions = _Descriptions, Nom = _Nom },
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
