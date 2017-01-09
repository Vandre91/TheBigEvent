using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class SalleService
    {
        readonly SalleLink _sLink;

        public SalleService(string connectionString)
        {
            _sLink = new SalleLink(connectionString);
        }

        //public void addUser(string _Nom, string _Cat, string _Prix, string _NbPersonnes, string _TraiteurId)
        //{
        //    _sLink.AddMenu(_Nom, _Cat, _Prix, _NbPersonnes, _TraiteurId);
        //}
        public Result<IEnumerable<Menu>> getmenu()
        {
            return Result.Success(Status.Ok, _sLink.GetAllSalle());
        }
    }
}
