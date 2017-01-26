using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.DAL;
using TheBigEvent.Services;
using TheBigEvent.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class EventController : Controller
    {
        readonly EventService _eventService;
        readonly TraiteurService _traiteurService;
        readonly MenuService _menuService;
        readonly SalleService _salleService;
        readonly DecoService _decoService;

        public EventController(EventService eventservice, TraiteurService traiteurservice, MenuService menuservice, SalleService salleservice, DecoService decoservice)
        {
            _eventService = eventservice;
            _traiteurService = traiteurservice;
            _menuService = menuservice;
            _salleService = salleservice;
            _decoService = decoservice;
        }

        [HttpGet("{method}")]
        public IActionResult GetEvent(string method)
        {
            switch (method)
            {
                case "Traiteur":
                    Result<IEnumerable<Traiteur>> result_traiteur = _traiteurService.getAllTraiteur();
                    return new JsonResult(result_traiteur);
                case "Menu":
                    Result<IEnumerable<Menu>> result_menu = _menuService.getmenu();
                    return new JsonResult(result_menu);
                case "Salle":
                    Result<IEnumerable<Salle>> result_salle = _salleService.getSalle();
                    return new JsonResult(result_salle);
                case "Deco":
                    Result<IEnumerable<Deco>> result_deco = _decoService.getDeco();
                    return new JsonResult(result_deco);
                default:
                    Result<IEnumerable<Event>> result_event = _eventService.getEvent();
                    return new JsonResult(result_event);
            }
        }

        [HttpPost("createEvent/")]
        public void createEvent([FromBody] EventViewModels model)
        {
            _eventService.addEvent(model.NomEvent, model.Localisation, model.MenuId, model.SalleId, model.TraiteurId, model.DecoId, model.UserId, model.NbInvite, model.Prix);
        }

        [HttpGet("event/traiteur/{id}")]
        public IActionResult GetEventbyidT(int id)
        {
            Result<IEnumerable<Event>> result = _eventService.getEventByIdPT(id);
            return new JsonResult(result);
        }

        [HttpGet("event/deco/{id}")]
        public IActionResult GetEventbyidD(int id)
        {
            Result<IEnumerable<Event>> result = _eventService.getEventByIdPD(id);
            return new JsonResult(result);
        }

        [HttpGet("event/salle/{id}")]
        public IActionResult GetEventbyidS(int id)
        {
            Result<IEnumerable<Event>> result = _eventService.getEventByIdPS(id);
            return new JsonResult(result);
        }
        [HttpGet("event/menu/{id}")]
        public IActionResult GetEventbyidM(int id)
        {
            Result<IEnumerable<Event>> result = _eventService.getEventByIdPM(id);
            return new JsonResult(result);
        }


        [HttpPost("validT")]
        public bool validT([FromBody] EventViewModels model)
        {           
            _eventService.validT(model.EventId, model.value);
            return (true);
        }

        [HttpPost("validD")]
        public bool validD([FromBody] EventViewModels model)
        {
            _eventService.validD(model.EventId, model.value);
            return (true);
        }

        [HttpPost("validS")]
        public bool validS([FromBody] EventViewModels model)
        {
            _eventService.validS(model.EventId, model.value);
            return (true);
        }

        [HttpPost("UpdateTraiteurIdbynull/{eventId}")]
        public void UpdateTraiteurIdbynull(int eventId)
        {
            _eventService.UpdateTraiteurIdbynull(eventId);
            return;
        }

        [HttpPost("UpdateMenuIdbynull/{eventId}")]
        public void UpdateMenuIdbynull(int eventId)
        {
            _eventService.UpdateMenuIdbynull(eventId);
            return;
        }

        [HttpPost("UpdateSalleIdbynull/{eventId}")]
        public void UpdateSalleIdbynull(int eventId)
        {
            _eventService.UpdateSalleIdbynull(eventId);
            return;
        }

        [HttpPost("UpdateDecoIdbynull/{eventId}")]
        public void UpdateDecoIdbynull(int eventId)
        {
            _eventService.UpdateDecoIdbynull(eventId);
            return;
        }
    }
}
