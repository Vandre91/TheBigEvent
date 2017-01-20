using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    public class ActionResultOptions<T, TViewModel>
    {
        public ActionResultOptions(Controller controller)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            Controller = controller;
        }

        public Func<T, TViewModel> ToViewModel { get; set; }

        public string RouteName { get; set; }

        public Func<T, object> RouteValues { get; set; }

        public Controller Controller { get; }
    }
}
