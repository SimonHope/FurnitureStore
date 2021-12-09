using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;

namespace FurnitureStore.Controllers
{
    public class StockController : Controller
    {
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
    }
}
