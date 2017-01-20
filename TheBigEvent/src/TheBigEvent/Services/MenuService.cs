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

        public Result<Menu> getMenubyid(int id)
        {
            Menu menu = _mLink.getMenu(id);
            return Result.Success(Status.Ok, menu);
        }

    }
}
