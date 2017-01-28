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
    public class EventProController : Controller
    {
        readonly EventService _eventService;
        readonly SalleService _salleService;
        readonly DecoService _decoService;
        readonly TraiteurService _traiteurService;

        public EventProController(EventService eventservice, SalleService salleService, DecoService decoService, TraiteurService traiteurService)
        {
            _eventService = eventservice;
            _salleService = salleService;
            _decoService = decoService;
            _traiteurService = traiteurService;
        }

        [HttpGet("{Id}")]
        public IActionResult GetEventPro(string id)
        {
            Result<IEnumerable<Event>> result_event = _eventService.getEventProById(id);
            return new JsonResult(result_event);
        }
        [HttpGet("Salle/{id}")]
        public IActionResult GetProSalle(int id)
        {
            Result<IEnumerable<Salle>> result_salle = _salleService.getSalleById(id);
            return new JsonResult(result_salle);
        }
        [HttpGet("Deco/{id}")]
        public IActionResult GetProDeco(int id)
        {
            Result<IEnumerable<Deco>> result_deco = _decoService.getDecoById(id);
            return new JsonResult(result_deco);
        }
        [HttpGet("Traiteur/{id}")]
        public IActionResult GetProTraiteur(int id)
        {
            Result<IEnumerable<Traiteur>> result_trait = _traiteurService.getTraiteurById(id);
            return new JsonResult(result_trait);
        }
        [HttpGet("SalleId/{id}")]
        public IActionResult GetEventSalle(int id)
        {
            Result<IEnumerable<Event>> result_event = _eventService.getEventSalle(id);
            return new JsonResult(result_event);
        }
        [HttpGet("DecoId/{id}")]
        public IActionResult GetEventDeco(int id)
        {
            Result<IEnumerable<Event>> result_event = _eventService.getEventDeco(id);
            return new JsonResult(result_event);
        }
        [HttpGet("TraiteurId/{id}")]
        public IActionResult GetEventTraiteur(int id)
        {
            Result<IEnumerable<Event>> result_event = _eventService.getEventTraiteur(id);
            return new JsonResult(result_event);
        }
    }
}
