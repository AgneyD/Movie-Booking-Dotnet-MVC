using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_booking.Data;
using Movie_booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _usermanager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            var item = _context.cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            return View(item);
        }

        public IActionResult cartempty() {
            TempData["cartempty"] = "Empty cart";
            return View();
        }
        public IActionResult proceed(cart cart) {
            var cartlist = _context.cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            if (cartlist.Count == 0)
            {
                return RedirectToAction("cartempty", "art");

            }
            else {
                return View(cartlist);
            }

        }
    }
}
