using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBigEvent.Services;
using TheBigEvent.DAL;
<<<<<<< HEAD
=======
using System.Security.Claims;
using TheBigEvent.Authentification;
using Microsoft.AspNetCore.Authorization;
>>>>>>> master

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    public class AcountController : Controller
    {
<<<<<<< HEAD
        // GET: /<controller>/
        public IActionResult Login()
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            ViewData["ListName"] = useService.returnAllNameUser();
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Mail, string Passe, string FirstName, string LastName, string City, string Tel, string Pro, string Siret, string Compagny)
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            useService.addUser(Mail, Passe, FirstName, LastName, City, Tel, Pro, Siret, Compagny);
            ViewData["ListName"] = useService.returnAllNameUser();
=======
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
        [HttpPost]
        public IActionResult Login(string Mail, string Passe, byte Pro, string Siret, string Compagny)
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            useService.addUser(Mail, Passe, Pro, Siret, Compagny);
>>>>>>> master
            return View();
        }

        public IActionResult Conexion()
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            ViewData["Firstname"] = "";
            return View();
        }
        [HttpPost]
<<<<<<< HEAD
        public IActionResult Conexion(string Mail, string Passe)
=======
        public async Task<IActionResult> Conexion(string Mail, string Passe)
>>>>>>> master
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            User user = useService.FindUser(Mail, Passe);
            if (user != null)
            {
<<<<<<< HEAD
                ViewData["Firstname"] = "Bonjour "+user.UserId+" !";
=======
                await SignIn(user.Mail, user.UserId.ToString());
                return RedirectToAction(nameof(Authenticated));

>>>>>>> master
            }
            else
            {
                ViewData["Firstname"] = "Erreur d'authentification !";
            }
            
            return View();
        }
<<<<<<< HEAD
=======
        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthentication.AuthenticationScheme)]
        public IActionResult Authenticated()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string email = User.FindFirst(ClaimTypes.Email).Value;
            Token token = _tokenService.GenerateToken(userId, email);
            ViewData["Token"] = token;
            ViewData["Email"] = email;
            ViewData["NoLayout"] = true;
            return View();
        }
        async Task SignIn(string email, string userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.Email, email, ClaimValueTypes.String ),
                new Claim( ClaimTypes.NameIdentifier, userId.ToString(), ClaimValueTypes.String )
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies", ClaimTypes.Email, string.Empty);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.Authentication.SignInAsync(CookieAuthentication.AuthenticationScheme, principal);
        }
>>>>>>> master
    }
}
