using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string PassengerContact { get; set; }
        public string EmailId { get; set; }
        public int? NoOfPassengers { get; set; }
        public int? BookingId { get; set; }
        public int? SeatNo { get; set; }

        public virtual TicketBooking Booking { get; set; }
    }
}
