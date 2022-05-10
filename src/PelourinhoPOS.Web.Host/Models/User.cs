using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class User
    {
        public User()
        {
            DocHeaders = new HashSet<DocHeader>();
            Pos = new HashSet<Po>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Nif { get; set; }
        public int? Tlm { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public int? AdminAccess { get; set; }
        public string NeedLogin { get; set; }
        public bool? Active { get; set; }
        public DateTime? SessionStarted { get; set; }
        public DateTime? SessionClosed { get; set; }
        public int? PosId { get; set; }
        public byte[] Version { get; set; }

        public virtual UsersAccessZone UsersAccessZone { get; set; }
        public virtual ICollection<DocHeader> DocHeaders { get; set; }
        public virtual ICollection<Po> Pos { get; set; }
    }
}
