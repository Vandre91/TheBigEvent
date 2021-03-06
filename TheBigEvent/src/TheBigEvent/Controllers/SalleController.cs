﻿using System;
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
    public class SalleController : Controller
    {
        readonly SalleService _salleService;

        public SalleController(SalleService salleService)
        {
            _salleService = salleService;
        }
        [HttpGet("{id}")]
        public IActionResult GetSalleByEvent(int id)
        {
            Result<IEnumerable<Salle>> result = _salleService.getSalleByEvent(id);
            return new JsonResult(result);
        }
    }
}
