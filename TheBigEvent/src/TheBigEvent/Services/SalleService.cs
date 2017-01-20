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
        
        public Result<IEnumerable<Salle>> getSalle()
        {
            return Result.Success(Status.Ok, _sLink.GetAllSalle());
        }
        public Result<IEnumerable<Salle>> getSalleByEvent(int _id)
        {
            return Result.Success(Status.Ok, _sLink.GetAllSalleByEvent(_id));
        }
    }
}
