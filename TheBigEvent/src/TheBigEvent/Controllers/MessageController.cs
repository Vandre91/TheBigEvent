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
    public class MessageController : Controller
    {
        readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet("{user1}")]
        public IActionResult GetMessageByEvent(int user1,int user2)
        {
            Result<IEnumerable<Message>> result = _messageService.getMessage(user2, user1);
            return new JsonResult(result);
        }
    }
}
