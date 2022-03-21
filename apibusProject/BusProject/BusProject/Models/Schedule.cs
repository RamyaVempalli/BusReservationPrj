using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int? UserId { get; set; }
        public int? BusId { get; set; }
        public int? DriverId { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? EstimatedArrivalTime { get; set; }
        public double? FareAmount { get; set; }
        public string Remark { get; set; }

        public virtual Bu Bus { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
