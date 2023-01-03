using Fileuploadcontrol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_booking.Data;
using Movie_booking.Models;
using Movie_booking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;

        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDetailViewmodel vmodel, moviedetails movie)
        {
            movie.Moviename = vmodel.Name;
            movie.Movie_Description = vmodel.Description;
            movie.DateandTime = vmodel.DateofMovie;
            foreach (var item in files)
            {
                movie.MoviePicture = "~/uploads/" + item.FileName.Trim();

            }
            _upload.uploadmultiplefile(files);
            _context.moviedetail.Add(movie);
            _context.SaveChanges();
            TempData["Success"] = "Save your movie";
            return RedirectToAction("Create", "Admin");

        }
        [HttpGet]
        public IActionResult checkbookseat() {
            var getbookingtable = _context.bookingtable.ToList().OrderByDescending(a => a.Datetopresent);
            return View(getbookingtable);
        }
        [HttpGet]
        public IActionResult userdetail() {
            var getusertable = _context.applicationUsers.ToList();
            return View(getusertable);
        }


    }
}
