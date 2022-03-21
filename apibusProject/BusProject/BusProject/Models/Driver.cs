using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
