using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBigEvent.Services;
using TheBigEvent.DAL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    public class AcountController : Controller
    {
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
            return View();
        }

        public IActionResult Conexion()
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            ViewData["Firstname"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult Conexion(string Mail, string Passe)
        {
            UserServices useService = new UserServices(@"Server = SHANE-PC\SQLEXPRESS; Database =TheBigEvent.DB ; Trusted_Connection = True");
            User user = useService.FindUser(Mail, Passe);
            if (user != null)
            {
                ViewData["Firstname"] = "Bonjour "+user.UserId+" !";
            }
            else
            {
                ViewData["Firstname"] = "Erreur d'authentification !";
            }
            
            return View();
        }
    }
}
