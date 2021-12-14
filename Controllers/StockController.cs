using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;

namespace FurnitureStore.Controllers
{
    public class StockController : Controller
    {
        string name;
        static List<BasketModel> basketlist = new List<BasketModel>()
        {

        };
        private ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Stocks.ToListAsync();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Product(int id)
        {
            var exist = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(exist);
        }

        public IActionResult ViewCart()
        {
            ViewBag.cart = basketlist;
            return View();
        }

        public IActionResult AddToCart(int id, string name, int price)
        {
            basketlist.Add(new BasketModel { Id = "184.22.13.251", StockId = id, StockName = name, Qty = 1, Price = price });
            return RedirectToAction("ViewCart");
        }

        public IActionResult DeleteCart(int id)
        {
            var exist = basketlist.FirstOrDefault(p => p.StockId == id);
            if (exist != null)
            {
                basketlist.Remove(exist);
            }
            return RedirectToAction("Index");
        }

        public async void StockIdToName(int id)
        {
            var raw = basketlist.FirstOrDefault(p => p.StockId == id);
            var stk = await _context.Stocks.Where(x => x.Id == raw.StockId).FirstOrDefaultAsync();
            string name = stk.Name;
        }
    }
}
