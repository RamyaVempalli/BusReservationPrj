using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
#nullable disable

namespace BusReservation1.Models
{
    [DataContract]
    public partial class Bu
    {
        internal object bus;

        public Bu()
        {
            Schedules = new HashSet<Schedule>();
        }
        [DataMember]
        public int BusId { get; set; }
        [DataMember]
        public string BusNo { get; set; }
        [DataMember]
        public string BusType { get; set; }
        [DataMember]
        public string BusName { get; set; }
        [DataMember]
        public string Departure { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public int? NoOfSeatsAvailable { get; set; }
        [DataMember]
        public int? Capacity { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
        [DataMember]
        public int? ReturnId { get; set; }
        [DataMember]
        public double? TicketPrice { get; set; }

        public virtual ReturnJourney Return { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
