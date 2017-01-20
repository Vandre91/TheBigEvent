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

        public bool addDecoByUserId(int UserId, string Descriptions, float Prix, string Nom)
        {
            _dLink.AddDeco(UserId, Descriptions, Prix, Nom);
            return (true);
        }


        public Result<Deco> getDecobyid(int id)
        {
            Deco deco = _dLink.getDeco(id);
            return Result.Success(Status.Ok, deco);
        }


    }
}
