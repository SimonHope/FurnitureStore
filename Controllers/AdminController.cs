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

        public async Task<IActionResult> AdminMember()
        {
            var contacts = await _context.Members.ToListAsync();
            return View(contacts);
        }
    
        [HttpGet]
        public IActionResult AdminMemberCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminMemberCreate(AdminMemberModel Members)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Members.AddAsync(Members);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("AdminMember");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
                
            }

            ModelState.AddModelError(string.Empty, "Something went wrong");

            return View(Members);
        }

        [HttpGet]
        public async Task<IActionResult> AdminMemberEdit(int id)
        {
            var exist = await _context.Members.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> AdminMemberEdit(AdminMemberModel Members)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _context.Members.Where(x => x.Id == Members.Id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if(exist != null)
                    {
                        exist.Username = Members.Username;
                        exist.Password = Members.Password;
                        exist.Name = Members.Name;
                        exist.Surname = Members.Surname;
                        exist.Address = Members.Address;

                        // we save the changes into the db
                        await _context.SaveChangesAsync();

                        return RedirectToAction("AdminMember");
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(Members);
        }

        [HttpGet]
        public async Task<IActionResult> AdminMemberDelete(int id)
        {
            var exist = await _context.Members.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> AdminMemberDelete(AdminMemberModel Members)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _context.Members.Where(x => x.Id == Members.Id).FirstOrDefault();

                    if(exist != null)
                    {
                        _context.Remove(exist);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("AdminMember");
                    } 
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }

        public IActionResult AdminProductCreate()
        {
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


    }
}
