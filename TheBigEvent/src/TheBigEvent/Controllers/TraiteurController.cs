using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using TheBigEvent.DAL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class TraiteurController : Controller
    {
        readonly TraiteurService _traiteurService;

        public TraiteurController(TraiteurService traiteurService)
        {
            _traiteurService = traiteurService;
        }
        [HttpGet("{id}")]
        public IActionResult GetTraiteurByEvent(int id)
        {
            Result<IEnumerable<Traiteur>> result = _traiteurService.getTraiteurByEvent(id);
            return new JsonResult(result);
        }
    }
}
