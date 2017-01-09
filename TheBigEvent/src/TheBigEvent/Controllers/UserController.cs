using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using Microsoft.DotNet.Cli.Utils.CommandParsing;
using TheBigEvent.DAL;
using TheBigEvent.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class UserController : Controller
    {
        readonly UserServices _userService;

        public UserController(UserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult GetUser(string email)
        {
            Services.Result<User> result = _userService.getUser(email);
            return new JsonResult(result);
            //return this.CreateResult<User, UserViewModel>(result, o =>
            //{
            //    o.ToViewModel = c => c.ToUserViewModel();
            //});
        }
        [HttpPost("{UserId}")]
        public IActionResult UpdateUser([FromBody] UserViewModel model)
        {
            
            Services.Result<User> result = _userService.UpdateUserName(model.UserId, model.FirstName, model.LastName, model.City, model.Tel);
            return this.CreateResult<User, UserViewModel>(result, o =>
            {
                o.ToViewModel = t => t.ToUserViewModel();
            });
        }







    }
}
