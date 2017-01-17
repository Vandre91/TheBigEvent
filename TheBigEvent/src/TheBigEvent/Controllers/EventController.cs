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

        public EventController(EventService eventservice, TraiteurService traiteurservice,MenuService menuservice,SalleService salleservice, DecoService decoservice)
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
           //     break;

                case "Menu":
                    Result<IEnumerable<Menu>> result_menu = _menuService.getmenu();
                    return new JsonResult(result_menu);
             //   break;
                case "Salle":
                    Result<IEnumerable<Salle>> result_salle = _salleService.getSalle();
                    return new JsonResult(result_salle);
             //   break;
                case "Deco":
                    Result<IEnumerable<Deco>> result_deco = _decoService.getDeco();
                    return new JsonResult(result_deco);
              //      break;

                default:
                    Result<IEnumerable<Event>> result_event = _eventService.getEvent();
                    return new JsonResult(result_event);
            //    break;
            }
            
        }
        [HttpPost]
        public void UpdateUser([FromBody] EventViewModels model)
        {

            _eventService.addEvent( model.NomEvent, model.Localisation, model.MenuId, model.SalleId, model.TraiteurId, model.DecoId, model.UserId);
            
        }



    }
}
