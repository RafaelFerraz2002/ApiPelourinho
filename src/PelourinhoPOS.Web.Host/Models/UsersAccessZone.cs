using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class UsersAccessZone
    {
        public int UserId { get; set; }
        public int ZoneId { get; set; }

        public virtual User User { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
