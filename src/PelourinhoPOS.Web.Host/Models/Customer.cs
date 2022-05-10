using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Customer
    {
        public Customer()
        {
            DocHeaders = new HashSet<DocHeader>();
            Pos = new HashSet<Po>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Nif { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? BoardId { get; set; }
        public int? DebtsToPay { get; set; }
        public bool? Active { get; set; }
        public int? PosId { get; set; }

        public virtual Board Board { get; set; }
        public virtual CustomerPo IdNavigation { get; set; }
        public virtual ICollection<DocHeader> DocHeaders { get; set; }
        public virtual ICollection<Po> Pos { get; set; }
    }
}
