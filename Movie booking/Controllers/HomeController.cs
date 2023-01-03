using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_booking.Data;
using Movie_booking.Models;
using Movie_booking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private ApplicationUser _userid;
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _user;

        private readonly ILogger<HomeController> _logger;
       
        

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> user)
        {
            _logger = logger;
            _context = context;
            _user = user;
            

        }

        public IActionResult Index()
        {
            var getmovielist = _context.moviedetail.ToList();
            return View(getmovielist);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Booknow(int Id) {

            BookNowViewmodel vm = new BookNowViewmodel();
            var item = _context.moviedetail.Where(a => a.Id == Id).FirstOrDefault();
            vm.Movie_name = item.Moviename;
            vm.Movie_date = item.DateandTime;
            vm.MovieId = Id;

            return View(vm);
        }

        




        [HttpPost]
        public IActionResult Booknow(BookNowViewmodel vm) {
            List<Booking_table> booking = new List<Booking_table>();
            List<cart> carts = new List<cart>();
            string seatno = vm.SeatNo.ToString();
            int movieId = vm.MovieId;

            string[] seatnoarray = seatno.Split(',');
            count = seatnoarray.Length;
            if (checkseat(seatno,movieId)==false)
            {
                foreach (var item in seatnoarray)
                {
                    carts.Add(new cart { Amount = 150, MovieId = vm.MovieId,UserId=_user.GetUserId(HttpContext.User), Date = vm.Movie_date, Seatno = item});
                }
                foreach (var item in carts)
                {
                    _context.cart.Add(item);
                    _context.SaveChanges();
                }
                TempData["Success"] = "Seat number Booked,check your cart";
            }
            else
            {
                TempData["seatnomsg"] = "Please Change seat number";
            }
            return RedirectToAction("Booknow");
        }

        private bool checkseat(string seatno, int movieId)
        {
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _context.bookingtable.Where(a => a.moviedetailsId == movieId).ToList();
            foreach (var item in seatnolist)
            {
                string alreadybooked = item.Seatno;
                foreach (var item1 in seatreserve)
                {
                    if (item1==alreadybooked)
                    {
                        flag = false;
                        break;

                    }
                }
            }
            if (flag==false)
            {
                return true;

            }
            else
            {
                return false;

            }
        }

        [HttpPost]
        public IActionResult checkseat(DateTime Movie_date,BookNowViewmodel booknow) 
        {

            string seatno = string.Empty;
            var movielist = _context.bookingtable.Where(a => a.Datetopresent == Movie_date);
            if (movielist!=null)
            {
                var getseatno = movielist.Where(b => b.moviedetailsId == booknow.MovieId).ToList();
                if (getseatno!=null)
                {
                    foreach (var item in getseatno)
                    {
                        seatno = seatno + " " + item.Seatno.ToString();

                    }
                    TempData["SNO"]="Already booked"+seatno;


                }

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
