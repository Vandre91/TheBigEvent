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

        public EventProController(EventService eventservice)
        {
            _eventService = eventservice;
        }

        [HttpGet("{Id}")]
        public IActionResult GetEventPro(string id)
        {
            Result<IEnumerable<Event>> result_event = _eventService.getEventProById(id);
            return new JsonResult(result_event);
        }
    }
}
