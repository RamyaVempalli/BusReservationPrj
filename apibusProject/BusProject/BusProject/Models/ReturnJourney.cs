using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class ReturnJourney
    {
        public ReturnJourney()
        {
            Bus = new HashSet<Bu>();
            TicketCancellations = new HashSet<TicketCancellation>();
        }

        public int ReturnId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnFrom { get; set; }
        public string ReturnTo { get; set; }
        public int? NoOfPassengers { get; set; }
        public double? ReturnTicketPrice { get; set; }
        public TimeSpan? ReturnTime { get; set; }

        public virtual ICollection<Bu> Bus { get; set; }
        public virtual ICollection<TicketCancellation> TicketCancellations { get; set; }
    }
}
