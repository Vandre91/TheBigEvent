using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class DecoService
    {
        readonly DecoLink _dLink;

        public DecoService(string connectionString)
        {
            _dLink = new DecoLink(connectionString);
        }

        public Result<IEnumerable<Deco>> getDeco()
        {
            return Result.Success(Status.Ok, _dLink.GetAllDeco());
        }
    }
}
