using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public virtual ICollection<Booking_table> Booking { get; set; }
    }
}
