using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_booking.Models.ViewModels
{
    public class BookNowViewmodel
    {
        public string Movie_name { get; set; }
        public DateTime Movie_date { get; set; }
        public string SeatNo { get; set; }
        public int Amount { get; set; }
        [Key]
        public int MovieId { get; set; }

    }
}
