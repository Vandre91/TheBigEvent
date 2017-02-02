using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;
using TheBigEvent.Models;

namespace TheBigEvent.Controllers
{
    public static class ModelProject
    {
        public static UserViewModel ToUserViewModel(this User @this)
        {
            return new UserViewModel
            {
                UserId = @this.UserId,
                _pass = @this.Passe,
                FirstName = @this.FirstName,
                LastName = @this.LastName,
                City = @this.City,
                Tel = @this.Tel,
                Mail = @this.Mail,
                Pro = @this.Pro,
                Siret = @this.Siret,
                Compagny = @this.Compagny
            };
        }
        public static EventViewModels ToEventViewModel(this Event @this)
        {
            return new EventViewModels
            {
                EventId = @this.EventId,
                NomEvent = @this.NomEvent,
                NbInvite = @this.NbInvite,
                Prix = @this.Prix,
                Dates = @this.Dates,
                MenuId = @this.MenuId,
                SalleId = @this.SalleId,
                TraiteurId = @this.TraiteurId,
                DecoId = @this.DecoId,
                Localisation = @this.Localisation,
                UserId = @this.UserId
            };
        }


    }
}
