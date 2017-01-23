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
        public Result<IEnumerable<Deco>> getDecoByEvent(int _id)
        {
            return Result.Success(Status.Ok, _dLink.GetAllDecoByEvent(_id));
        }
        public bool addDecoByUserId(int UserId, string Descriptions, float Prix, string Nom)
        {
            _dLink.AddDeco(UserId, Descriptions, Prix, Nom);
            return (true);
        }


        public Result<IEnumerable<Deco>> getDecobyid(int id)
        {
            return Result.Success(Status.Ok, _dLink.getDeco(id));
        }

        public void DeleteDeco(int _id)
        {
            _dLink.Delete(_id);
        }

    }
}
