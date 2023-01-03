using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Models
{
    public class Booking_table
    {
        public int Id { get; set; }
        public string Seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Datetopresent { get; set; }
        public int moviedetailsId { get; set; }
        public int Amount { get; set; }

        [ForeignKey("moviedetailsId")]
        public virtual moviedetails moviedetail { get; set; }

    }

}
