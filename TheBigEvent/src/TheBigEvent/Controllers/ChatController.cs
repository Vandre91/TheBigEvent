using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBigEvent.Services;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.DAL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class ChatController : Controller
    {
        readonly UserServices _userService;
        readonly EventService _eventService;

        public ChatController(UserServices userService, EventService eventService)
        {
            _userService = userService;
            _eventService = eventService;
        }
        //[HttpGet("{id}")]
        //public IActionResult GetMessage()
        //{
        //Result<IEnumerable<Traiteur>> result = _eventService.getEventById();
        //return new JsonResult(result);
        //}
    }
}
