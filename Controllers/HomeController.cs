using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;

namespace FurnitureStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        

        

        public IActionResult AdminMember()
        {
            List<AdminMemberModel> ls = new List<AdminMemberModel>();
            ls.Add(new AdminMemberModel { Id = 001, Username = "61010910", Name = "Nuthapong", Surname = "Poonperm", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            ls.Add(new AdminMemberModel { Id = 002, Username = "61011215", Name = "Arune", Surname = "Dansugchai", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            ls.Add(new AdminMemberModel { Id = 003, Username = "62015021", Name = "Chayanin", Surname = "Buasala", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            ls.Add(new AdminMemberModel { Id = 004, Username = "62015038", Name = "Nutthapoom", Surname = "lomkret", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            ls.Add(new AdminMemberModel { Id = 005, Username = "62015063", Name = "Nuthapong", Surname = "Poonperm", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            ls.Add(new AdminMemberModel { Id = 006, Username = "62015131", Name = "Authapol", Surname = "Tuntiwatthanapol", Picture = "https://www.inhome.co.th/wp-content/uploads/2018/10/be-1560-s-cem-2.jpg" });
            return View(ls.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
