using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_Client.Areas.OrganizationManager
{
    [Area("OrganizationManager")]
    public class EspaceProController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MesInformations()
        {
            return View();
        }

        public IActionResult MesInsertions()
        {
            return View();
        }

        public IActionResult ListeOrganisation()
        {
            return View();
        }

    }
}
