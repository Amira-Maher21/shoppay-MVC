using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoppayData.Data;
using shoppayEntieys.Repository;
using shoppayUtilites;
using System.Security.Claims;

namespace shoppayMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ShopDbcontext _context;
        public UsersController(ShopDbcontext context)
        {
            _context = context;
        }


        //public IActionResult Index()
        //{
        // var claimsIdentity = User.Identity as ClaimsIdentity;
        // var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


        //    return View();
        //}




        public IActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                return Unauthorized(); // أو التعامل مع الحالة بشكل مناسب
            }

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return Unauthorized(); // أو التعامل مع الحالة بشكل مناسب
            }

            string userid = claim.Value;
            var users = _context.applicationUsers
                                .Where(x => x.Id != userid)
                                .ToList();

            return View(users);
        }
        public IActionResult LockUnlock(string? id)
        {
            var user = _context.applicationUsers.FirstOrDefault(x => x.Id == id);   
            if (user == null)
            {
                return NotFound();
            }
            if (user.LockoutEnd == null || user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now.AddYears(1);
            }
            else
            {
               user.LockoutEnd= DateTime.Now;
            }
           _context.SaveChanges();
            return RedirectToAction("Index","Users", new {area="Admin"});
        }
    }
}    
    

