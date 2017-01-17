using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBigEvent.Services;
using TheBigEvent.DAL;
using System.Security.Claims;
using TheBigEvent.Authentification;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    public class AcountController : Controller
    {
        readonly UserServices _userService;
        readonly TokenService _tokenService;

        public AcountController(UserServices userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        //inscription
        [HttpPost]
        public IActionResult Login(string Mail, string Passe, byte Pro, string Siret, string Compagny)
        {
            UserServices useService = new UserServices(@"Server =  SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            useService.addUser(Mail, Passe, Pro, Siret, Compagny);
            return View();
        }
        //connection sans utilisateur
        public IActionResult Conexion()
        {
            UserServices useService = new UserServices(@"Server =  SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            ViewData["Firstname"] = "";
            return View();
        }

        // connection avec le mail et mot de passe
        [HttpPost]
        public async Task<IActionResult> Conexion(string Mail, string Passe)
        {
            UserServices useService = new UserServices(@"Server =  SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            User user = useService.FindUser(Mail, Passe);
            if (user != null)
            {
                await SignIn(user.Mail, user.UserId.ToString(), user.Pro);
                return RedirectToAction(nameof(Authenticated));

            }
            else
            {
                ViewData["Firstname"] = "Erreur d'authentification !";
            }
            
            return View();
        }



        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthentication.AuthenticationScheme)]
        public IActionResult Authenticated()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string email = User.FindFirst(ClaimTypes.Email).Value;
            bool id = bool.Parse(User.FindFirst(ClaimTypes.Authentication).Value);
            Token token = _tokenService.GenerateToken(userId, email, id);
            ViewData["Token"] = token;
            ViewData["Email"] = email;
            ViewData["id"] = id;
            ViewData["NoLayout"] = true;
            return View();
        }


        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthentication.AuthenticationScheme)]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthentication.AuthenticationScheme);
            ViewData["NoLayout"] = true;
            return View();
        }
        async Task SignIn(string email, string userId, bool pro)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.Email, email, ClaimValueTypes.String ),
                new Claim( ClaimTypes.Authentication, pro.ToString(), ClaimValueTypes.Boolean ),
                new Claim( ClaimTypes.NameIdentifier, userId.ToString(), ClaimValueTypes.String )
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies", ClaimTypes.Email, string.Empty);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.Authentication.SignInAsync(CookieAuthentication.AuthenticationScheme, principal);
        }
    }
}
