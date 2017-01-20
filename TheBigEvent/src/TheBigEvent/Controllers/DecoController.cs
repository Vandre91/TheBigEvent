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
    public class DecoController : Controller
    {
        readonly DecoService _decoService;

        public DecoController(DecoService decoService)
        {
            _decoService = decoService;
        }
        [HttpGet("{id}")]
        public IActionResult GetDecoByEvent(int id)
        {
            Result<IEnumerable<Deco>> result = _decoService.getDecoByEvent(id);
            return new JsonResult(result);
        }
    }
}
