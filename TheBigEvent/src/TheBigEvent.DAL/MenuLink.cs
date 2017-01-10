using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class MenuLink
    {
        readonly string _connectionString;

        public MenuLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Menu> GetAllMenu()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Menu>("Select *, tbe.tUser.Compagny as Compagny From tbe.tMenu join tbe.tTraiteur ON tbe.tTraiteur.TraiteurId = tbe.tMenu.TraiteurId JOIN tbe.tUser ON tbe.tUser.UserId = tbe.tTraiteur.UserId");
            }
        }
        public void AddMenu(string _Nom, string _Cat, string _Prix, string _NbPersonnes, string _TraiteurId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddMenu",
                    new { Nom = _Nom, Cat = _Cat, Prix = _Prix, NbPersonnes = _NbPersonnes, TraiteurId = _TraiteurId },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(int _MenuId, string _Nom,string _Cat,string _Prix,string _NbPersonne)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUpdateMenu",
                    new { MenuId = _MenuId, Nom = _Nom, Cat = _Cat,Prix = _Prix, NbPersonnes = _NbPersonne },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int _MenuId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteMenu",
                    new { MenuId = _MenuId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
