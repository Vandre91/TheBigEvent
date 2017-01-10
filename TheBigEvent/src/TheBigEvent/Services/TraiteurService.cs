using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class TraiteurService
    {
        readonly TraiteurLink _eLink;
        public TraiteurService(string connectionString)
        {
            _eLink = new TraiteurLink(connectionString);
        }
        public Result<IEnumerable<Traiteur>> getAllTraiteur()
        {
            return Result.Success(Status.Ok, _eLink.GetAlltraiteur());
        }
    }
}
