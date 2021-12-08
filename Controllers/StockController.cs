using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;

namespace FurnitureStore.Controllers
{
    public class StockController : Controller
    {
        public StockController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
