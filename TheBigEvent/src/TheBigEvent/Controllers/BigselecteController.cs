using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using TheBigEvent.Models;
using TheBigEvent.DAL;

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

        [HttpPost("createBigSelect/")]
        public Result<BigSelecte> createBigSelect([FromBody] BigSelecteViewModels model)
        {
            return _bigselecteService.addBigSelecte( model.UserId, model.Nom, model.Ville, model.Description);
        }
        [HttpPost("createInvite/")]
        public void createInvite([FromBody] InviteViewModels model)
        {
            _inviteService.addInvite(model.BigSelecteId, model.Nom, model.Mail);
        }
        [HttpPost("createDate/")]
        public void createDate([FromBody] DateViewModels model)
        {
            _dateService.addDate(model.Dates, model.BigSelecteId);
        }
        [HttpPost("createValidation/")]
        public void createValidation([FromBody] ValidationViewModels model)
        {
            _validationService.addValidation(model.PropositionId, model.ValidationId);
        }
    }
}
