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
        public Result<IEnumerable<Traiteur>> getTraiteurByEvent(int _id)
        {
            return Result.Success(Status.Ok, _eLink.GetAlltraiteurByEvent(_id));
        }
        public Result<Traiteur> getTraiteur(int id)
        {
            Traiteur traiteur = _eLink.getTraiteur(id);
            return Result.Success(Status.Ok, traiteur);
        }
        public bool addTraiteurByUserId(int UserId, string Descriptions, string Nom)
        {
            _eLink.AddTraiteur(UserId, Descriptions, Nom);
            return (true);
        }

        public void DeleteTraiteur(int _id)
        {
            _eLink.Delete(_id);
        }
    }
}
