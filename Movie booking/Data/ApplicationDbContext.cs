using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_booking.Models;
using Movie_booking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_booking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking_table> bookingtable { get; set; }
        public DbSet<cart> cart{ get; set; }
        public DbSet<moviedetails> moviedetail { get; set; }
        public DbSet<Movie_booking.Models.ViewModels.MovieDetailViewmodel> MovieDetailViewmodel { get; set; }
        public DbSet<Movie_booking.Models.ViewModels.BookNowViewmodel> BookNowViewmodel { get; set; }

        public DbSet<ApplicationUser> applicationUsers { get; set; }


    }
}
