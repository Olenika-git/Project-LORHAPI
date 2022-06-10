﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
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
