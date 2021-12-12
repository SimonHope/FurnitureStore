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

        public async Task<IActionResult> Product()
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

         public async Task<IActionResult> AdminMember()
        {

            var contacts = await _context.Members.ToListAsync();
            return View(contacts);
        }
        

        public IActionResult AdminProduct()
        {
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            
            if(username == null && password == null){
                ViewBag.error = "กรุณใส่ช่องลงชื่อเข้าใช้";
                return View("Login");

            }
            else{
                if (username.Equals("admin") && password.Equals("123456"))
            {
                
                return View("AdminDashboard");
            }
            else
            {
                ViewBag.error = "เข้าสู่ระบบไม่สำเร็จ";
                ViewBag.alertMessage = "เข้าสู่ระบบไม่สำเร็จ";
                return View("Login");
            }

            }
        }

        
        

        // public IActionResult Login(string username, string password)
        // {

        //     var admindata = _context.Members.ToListAsync();
        //     bool adminuser = _context.Members.Where(x => x.Username == username).FirstOrDefaultAsync();
        //     bool adminpass = _context.Members.Where(x => x.Password == password).FirstOrDefaultAsync();
            
        //     if (username == null && password == null)
        //     {
        //         ViewBag.error = "กรุณใส่ช่องลงชื่อเข้าใช้";
        //         return View("Login");

        //     }
        //     else
        //     {
        //         if (username.Equals(adminuser) && password.Equals(adminpass))
        //         {

        //             return View("AdminDashboard");
        //         }
        //         else
        //         {
        //             ViewBag.error = "เข้าสู่ระบบไม่สำเร็จ";
        //             ViewBag.alertMessage = "เข้าสู่ระบบไม่สำเร็จ";
        //             return View("Login");
        //         }

        //     }
        // }


    



        


    }
}
