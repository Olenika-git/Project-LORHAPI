using LORHAPI_Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_Client.Areas.Admin.Controllers
{
    //[Authorize ("Roles=Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users(List<User> Users)
        {
            
            return View();

        }

        public IActionResult Insertions()
        {
            return View();

        }

        public IActionResult Organizations()
        {
            return View();

        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
