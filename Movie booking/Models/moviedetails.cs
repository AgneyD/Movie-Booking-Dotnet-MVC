using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Models
{
    public class moviedetails
    {
        public int Id { get; set; }
        public string Moviename { get; set; }
        public string Movie_Description { get; set; }
        public DateTime DateandTime { get; set; }

        public string  MoviePicture { get; set; }

        public virtual ICollection<Booking_table> Booking { get; set; }
    }
}
