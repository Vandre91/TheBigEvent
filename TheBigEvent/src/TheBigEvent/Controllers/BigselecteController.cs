using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using TheBigEvent.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class BigSelecteController : Controller
    {
        // GET: /<controller>/
        readonly BigSelecteService _bigselecteService;
        readonly InviteService _inviteService;
        readonly DateService _dateService;
        readonly ValidationService _validationService;

        public BigSelecteController(BigSelecteService bigselecteservice, InviteService inviteservice, DateService dateservice, ValidationService validationservice)
        {
            _bigselecteService = bigselecteservice;
            _inviteService = inviteservice;
            _dateService = dateservice;
            _validationService = validationservice;
        }

        [HttpPost("createBigSelecte/")]
        public void createBigSelecte([FromBody] BigSelecteViewModels model)
        {
            _bigselecteService.addBigSelecte( model.UserId, model.Nom, model.Ville, model.Description);
        }
        [HttpPost("createInvite/")]
        public void createInvite([FromBody] EventViewModels model)
        {
            _inviteService.addInvite(model.NomEvent, model.Localisation, model.MenuId, model.SalleId, model.TraiteurId, model.DecoId, model.UserId, model.NbInvite, model.Prix, model.Dates);
        }
        [HttpPost("createDate/")]
        public void createDate([FromBody] EventViewModels model)
        {
            _dateService.addDate(model.NomEvent, model.Localisation, model.MenuId, model.SalleId, model.TraiteurId, model.DecoId, model.UserId, model.NbInvite, model.Prix, model.Dates);
        }
        [HttpPost("createValidation/")]
        public void createValidation([FromBody] EventViewModels model)
        {
            _validationService.addValidation(model.NomEvent, model.Localisation, model.MenuId, model.SalleId, model.TraiteurId, model.DecoId, model.UserId, model.NbInvite, model.Prix, model.Dates);
        }
    }
}
