using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_Client.Areas.Basic.Controllers
{
    [Area("Users")]
    public class EspaceProController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
