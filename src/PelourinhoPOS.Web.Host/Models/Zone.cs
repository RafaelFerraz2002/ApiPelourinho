using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Boards = new HashSet<Board>();
            DocHeaders = new HashSet<DocHeader>();
            Pos = new HashSet<Po>();
            UsersAccessZones = new HashSet<UsersAccessZone>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? Acess { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public int? PosId { get; set; }
        public byte[] Version { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<DocHeader> DocHeaders { get; set; }
        public virtual ICollection<Po> Pos { get; set; }
        public virtual ICollection<UsersAccessZone> UsersAccessZones { get; set; }
    }
}
