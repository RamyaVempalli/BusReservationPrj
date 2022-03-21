using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class TicketBooking
    {
        public TicketBooking()
        {
            Passengers = new HashSet<Passenger>();
            Payments = new HashSet<Payment>();
            TicketCancellations = new HashSet<TicketCancellation>();
        }

        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? NoOfTickets { get; set; }
        public int? NoOfSeats { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public double? TicketPrice { get; set; }
        public string BookingStatus { get; set; }
        public double? FareAmount { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TicketCancellation> TicketCancellations { get; set; }
    }
}
