using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class MenuService
    {
        readonly MenuLink _mLink;

        public MenuService(string connectionString)
        {
            _mLink = new MenuLink(connectionString);
        }

        public Result<IEnumerable<Menu>> getmenu()
        {
            return Result.Success(Status.Ok, _mLink.GetAllMenu());
        }

        public bool addMenuByTraiteurId(string nom, string cat, int Prix, int NbPersonnes, int TraiteurId)
        {
            _mLink.AddMenu(nom, cat, Prix, NbPersonnes, TraiteurId);
            return (true);
        }

        public Result<IEnumerable<Menu>> getMenubyid(int id)
        {
            return Result.Success(Status.Ok, _mLink.getMenu(id));
        }

        public void DeleteAllMenubyId(int TraiteurId)
        {
            _mLink.DeleteAllMenubyId(TraiteurId);
        }

        public void DeleteMenu(int _id)
        {
            _mLink.Delete(_id);
        }

    }
}
