using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Cartshop()
        {
            return View();
        }

        public ActionResult Confirm()
		{
			return View();
		}
        public ActionResult OrderCreate()
		{
			return View();
		}
        public async Task<IActionResult> ConfirmOrder()
        {
            var contacts = await _context.Order.ToListAsync();
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(OrderModel Order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Order.AddAsync(Order);
                    await _context.SaveChangesAsync();
                    
                    
                    return RedirectToAction("Product");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }

            }

            ModelState.AddModelError(string.Empty, "Something went wrong");

            return View(Order);
        }

        [HttpGet]
        public async Task<IActionResult> AdminMemberEdit(int id)
        {
            var exist = await _context.Members.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
