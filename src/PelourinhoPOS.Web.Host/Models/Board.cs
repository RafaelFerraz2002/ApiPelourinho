using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Board
    {
        public Board()
        {
            Customers = new HashSet<Customer>();
            DocHeaders = new HashSet<DocHeader>();
        }

        public int Id { get; set; }
        public int? ZoneId { get; set; }
        public int? Value { get; set; }
        public bool? InUse { get; set; }
        public string Image { get; set; }
        public int? CoordY { get; set; }
        public int? CoordX { get; set; }
        public int? BoardNumber { get; set; }
        public string Color { get; set; }
        public byte[] Version { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DocHeader> DocHeaders { get; set; }
    }
}
