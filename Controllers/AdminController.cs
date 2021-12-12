using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FurnitureStore.Models;
using FurnitureStore.Data;
using System.Collections.Generic;

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
                if (username.Equals("admin") && password.Equals("123"))
            {

                return View("AdminDashboard");
            }
            else
            {
                ViewBag.error = "เข้าสู่ระบบไม่สำเร็จ";
                return View("Login");
            }

            }

            
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
