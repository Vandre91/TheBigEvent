using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.DAL;
using TheBigEvent.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]/fdp")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class EventController : Controller
    {
        readonly EventService _eventService;
        readonly TraiteurService _traiteurService;

        public EventController(EventService eventservice, TraiteurService traiteurservice)
        {
            _eventService = eventservice;
            _traiteurService = traiteurservice;
        }

        [HttpGet("{method}",Name = "event")]
        public IActionResult GetEvent()
        {
            Result<IEnumerable<Event>> result = _eventService.getEvent();
            return new JsonResult(result);
        }

        [HttpGet("{Traiteur}")]
        public IActionResult GetTraiteur()
        {
            Result<IEnumerable<Event>> result = _eventService.getEvent();
            return new JsonResult(result);
        }





    }
}
