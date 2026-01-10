using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCWebApp.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Greet()
        {
            return View();
        }
    }
}