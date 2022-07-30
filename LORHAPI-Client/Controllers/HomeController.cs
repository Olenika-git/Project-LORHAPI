using LORHAPI_Client.Areas.User.Models;
using LORHAPI_Client.Http;
using LORHAPI_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LORHAPI_Client.Controllers
{
    public class HomeController : Controller
    {
        private InsertionApi _api = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public ActionResult Index()
        {
            List<Insertion> insertions = new List<Insertion>();
            List<Department> departments = new List<Department>();
            HttpClient client  = _api.Initial();
            dynamic monModel = new ExpandoObject();

            HttpResponseMessage response = client.GetAsync("/Insertions").Result;
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                insertions = JsonConvert.DeserializeObject<List<Insertion>>(results);
            }
            HttpResponseMessage responseDep = client.GetAsync("/Department").Result;
            if (responseDep.IsSuccessStatusCode)
            {
                var resultsDep = responseDep.Content.ReadAsStringAsync().Result;
                departments = JsonConvert.DeserializeObject<List<Department>>(resultsDep);
            }

            monModel.Insertions = insertions;
            monModel.Departments = departments;
            return View(monModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Connection()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
