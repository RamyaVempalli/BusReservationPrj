using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class Bu
    {
        public Bu()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int BusId { get; set; }
        public string BusNo { get; set; }
        public string BusType { get; set; }
        public string BusName { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int? NoOfSeatsAvailable { get; set; }
        public int? Capacity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ReturnId { get; set; }
        public double? TicketPrice { get; set; }

        public virtual ReturnJourney Return { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
