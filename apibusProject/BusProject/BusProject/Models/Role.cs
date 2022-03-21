using System;
using System.Collections.Generic;

#nullable disable

namespace BusProject.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
        public string RoleDescription { get; set; }
        public int? UserId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
