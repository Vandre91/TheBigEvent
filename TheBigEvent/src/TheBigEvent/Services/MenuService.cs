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

        public void addMenu(string _Nom, string _Cat, string _Prix, string _NbPersonnes, string _TraiteurId)
        {
            _mLink.AddMenu(_Nom, _Cat, _Prix, _NbPersonnes, _TraiteurId);
        }
        public Result<IEnumerable<Menu>> getmenu()
        {
            return Result.Success(Status.Ok, _mLink.GetAllMenu());
        }

    }
}
