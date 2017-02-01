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
                //                return con.Query<Menu>("Select *, tbe.tUser.Compagny as Compagny From tbe.tMenu join tbe.tTraiteur ON tbe.tTraiteur.TraiteurId = tbe.tMenu.TraiteurId JOIN tbe.tUser ON tbe.tUser.UserId = tbe.tTraiteur.UserId");
                return con.Query<Menu>("Select tbe.tTraiteur.*, tbe.tMenu.*, u.Compagny, u.City from tbe.tTraiteur, tbe.tMenu, tbe.tUser u where tbe.tTraiteur.TraiteurId = tbe.tMenu.TraiteurId and u.UserId = tbe.tTraiteur.UserId;");
            }
        }

        public IEnumerable<Menu> getMenu(int _TraiteurId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Menu>("select * from tbe.tMenu where TraiteurId = @TraiteurId ;",
                        new
                        {
                            TraiteurId = _TraiteurId
                        });
            }
        }




        public void AddMenu(string _Nom, string _entrer, string _plat, string _dessert, int _Prix, int _NbPersonnes, int _TraiteurId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pAddMenu",
                    new { Nom = _Nom, Entrer = _entrer, Plat = _plat, Dessert = _dessert, Prix = _Prix, NbPersonnes = _NbPersonnes, TraiteurId = _TraiteurId },
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

        public void DeleteAllMenubyId(int _TraiteurId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteMenubyId",
                    new { TraiteurId = _TraiteurId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
