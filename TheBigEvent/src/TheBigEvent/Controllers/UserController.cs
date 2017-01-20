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
        readonly SalleService _salleService;
        readonly DecoService _decoService;
        readonly TraiteurService _traiteurService;
        readonly MenuService _menuService;

        public UserController(UserServices userService, SalleService salleService, DecoService decoService, TraiteurService traiteurService, MenuService menuService)
        {
            _userService = userService;
            _salleService = salleService;
            _decoService = decoService;
            _traiteurService = traiteurService;
            _menuService = menuService;
        }

        [HttpGet("{email}")]
        public IActionResult GetUser(string email)
        {
            Services.Result<User> result = _userService.getUser(email);
            return new JsonResult(result);
        }
        
        [HttpGet("getTraiteur/{UserId}")]
        public IActionResult getTraiteur(int id)
        {
            Services.Result<Traiteur> result = _traiteurService.getTraiteur(id);
            return new JsonResult(result);
        }

        [HttpGet("getSalle/{UserId}")]
        public IActionResult getSalle(int id)
        {
            Services.Result<Salle> result = _salleService.getSallebyid(id);
            return new JsonResult(result);
        }

        [HttpGet("getDeco/{UserId}")]
        public IActionResult getDeco(int id)
        {
            Services.Result<Deco> result = _decoService.getDecobyid(id);
            return new JsonResult(result);
        }

        [HttpGet("getMenu/{Id}")]
        public IActionResult getMenu(int id)
        {
            Services.Result<Menu> result = _menuService.getMenubyid(id);
            return new JsonResult(result);
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

        [HttpPost("salle/{UserId}")]
        public bool AddSalle([FromBody] SalleViewModels model)
        {
           bool result = false;
           result = _salleService.addSalleByUserId(model.NbPlace, model.UserId, model.Description, model.Prix, model.Nom);
           return (result);
        }

        [HttpPost("deco/{UserId}")]
        public bool AddDeco([FromBody] DecoViewModels model)
        {
            bool result = false;
            result = _decoService.addDecoByUserId(model.UserId, model.Description, model.Prix, model.Nom);
            return (result);
        }

        [HttpPost("traiteur/{UserId}")]
        public bool AddTraiteur([FromBody] TraiteurViewModels model)
        {
            bool result = false;
            result = _traiteurService.addTraiteurByUserId(model.UserId, model.Descriptions, model.Nom);
            return (result);
        }

        [HttpPost("menu/{UserId}")]
        public bool AddMenu([FromBody] MenuViewModels model)
        {
            bool result = false;
            result = _menuService.addMenuByTraiteurId(model.Nom, model.Cat, model.Prix, model.NbPersonnes, model.TraiteurId);
            return (result);
        }

        [HttpPut("{UserId}")]
        public IActionResult UpdateUserMail([FromBody] UserViewModel model)
        {

            Services.Result<User> result = _userService.UpdateUserMail(model.UserId,model.Mail,model.Passe);
            return this.CreateResult<User, UserViewModel>(result, o =>
            {
                o.ToViewModel = t => t.ToUserViewModel();
            });
        }

        [HttpDelete("{UserId}")]
        public void DeleteUserMail(int UserId)
        {
            _userService.DeleteUser(UserId);
        }
        

    }
}
