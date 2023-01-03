using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Models
{
    public class cart
    {
        public int Id { get; set; }
        public string Seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Date{ get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }
    }
}
