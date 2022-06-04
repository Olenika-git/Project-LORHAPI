using LORHAPI_Client.Areas.User.Models;
using LORHAPI_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LORHAPI_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Student
        public ActionResult Index()
        {
            List<User> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5001/");
                //HTTP GET
                var responseTask = client.GetAsync("users");
                responseTask.Wait();
                
                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<User>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else //web api sent error response 
                {
                  
                    
                    

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(users);
        }

        public IActionResult Privacy()
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
