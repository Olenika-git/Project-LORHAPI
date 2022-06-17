using LORHAPI_Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_Client.Areas.OrgManager.Controllers
{
    //[Authorize ("Roles=Admin")]
    [Area("OrgManager")]
    public class HomeController : Controller
    {
        public CurrentUser User { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();

        }

        public IActionResult Insertions()
        {
            return View();

        }
        public IActionResult Profile()
        {
            return View();
        }

    }
}
