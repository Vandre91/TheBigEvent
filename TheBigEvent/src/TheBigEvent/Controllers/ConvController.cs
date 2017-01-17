using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using TheBigEvent.DAL;
using TheBigEvent.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class ConvController : Controller
    {
        
        readonly UserServices _userService;
        readonly EventService _eventService;

        public ConvController(UserServices userService, EventService eventService)
        {
            _userService = userService;
            _eventService = eventService;
        }
        [HttpGet("{id}")]
        public IActionResult GetAllConv(string id)
        {
            Result<IEnumerable<Event>> result = _eventService.getEventById(id);
            return new JsonResult(result);
        }
    }
}
