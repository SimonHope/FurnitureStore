using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;

namespace FurnitureStore.Controllers
{
    public class AdminusernameController : Controller
    {
         private ApplicationDbContext _context;
        public AdminusernameController(ApplicationDbContext context)
        {
            _context = context;
        }
        


        


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
