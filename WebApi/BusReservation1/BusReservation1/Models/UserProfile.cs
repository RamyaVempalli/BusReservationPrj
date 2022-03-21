using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusReservation1.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Drivers = new HashSet<Driver>();
            Roles = new HashSet<Role>();
            Schedules = new HashSet<Schedule>();
            TicketBookings = new HashSet<TicketBooking>();
        }
     
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public DateTime? Dob { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
