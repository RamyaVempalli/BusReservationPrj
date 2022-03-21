using System;
using System.Collections.Generic;

#nullable disable

namespace BusReservation1.Models
{
    public partial class TicketCancellation
    {
        public int CancellationId { get; set; }
        public int? BookingId { get; set; }
        public string IsCancel { get; set; }
        public double? IsRefund { get; set; }
        public DateTime? IsReschedule { get; set; }
        public int? ReturnId { get; set; }

        public virtual TicketBooking Booking { get; set; }
        public virtual ReturnJourney Return { get; set; }
    }
}
