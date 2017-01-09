﻿using System;
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
                Passe = @this.Passe,
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

        
    }
}