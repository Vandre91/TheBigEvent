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

        public Result<Salle> getSallebyid(int id)
        {
            Salle salle = _sLink.getSalle(id);
            return Result.Success(Status.Ok, salle);
        }


    }
}
