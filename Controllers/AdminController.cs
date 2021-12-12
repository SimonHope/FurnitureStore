using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;
using System.Collections.Generic;
using System;

namespace FurnitureStore.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdminProduct()
        {
            var contacts = await _context.Stocks.ToListAsync();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult AdminProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminProductCreate(StockModel Stocks)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Stocks.AddAsync(Stocks);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("AdminProduct");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }

            }

            ModelState.AddModelError(string.Empty, "Something went wrong");

            return View(Stocks);
        }

        [HttpGet]
        public async Task<IActionResult> AdminProductEdit(int id)
        {
            var exist = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> AdminProductEdit(StockModel Stocks)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _context.Stocks.Where(x => x.Id == Stocks.Id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if (exist != null)
                    {
                        exist.Name = Stocks.Name;
                        exist.Desc = Stocks.Desc;
                        exist.Price = Stocks.Price;
                        exist.Disc = Stocks.Disc;
                        exist.Image = Stocks.Image;

                        // we save the changes into the db
                        await _context.SaveChangesAsync();

                        return RedirectToAction("AdminProduct");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(Stocks);
        }

        [HttpGet]
        public async Task<IActionResult> AdminProductDelete(int id)
        {
            var exist = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> AdminProductDelete(StockModel Stocks)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _context.Stocks.Where(x => x.Id == Stocks.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        _context.Remove(exist);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("AdminProduct");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }





        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AdminOrder()
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


    }
}
