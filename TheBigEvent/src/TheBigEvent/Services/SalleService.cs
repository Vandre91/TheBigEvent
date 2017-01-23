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

        public bool addSalleByUserId(int NbPlace, int UserId, string Description, float Prix, string Nom)
        {
            _sLink.AddSalle(NbPlace, UserId, Description, Prix, Nom);
            return (true);
        }

        public Result<IEnumerable<Salle>> getSallebyid(int id)
        {
            return Result.Success(Status.Ok, _sLink.getSalle(id));
        }

        public void DeleteSalle(int _id)
        {
            _sLink.Delete(_id);
        }
    }
}
