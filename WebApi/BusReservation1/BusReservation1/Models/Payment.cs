using System;
using System.Collections.Generic;

#nullable disable

namespace BusReservation1.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? AmountPaid { get; set; }

        public virtual TicketBooking Booking { get; set; }
    }
}
