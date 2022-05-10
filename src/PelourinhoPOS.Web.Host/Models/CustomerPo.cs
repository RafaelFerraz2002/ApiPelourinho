using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class CustomerPo
    {
        public int CustomerId { get; set; }
        public int? BoardId { get; set; }
        public int? DebtsToPay { get; set; }
        public bool? Active { get; set; }
        public int? PosId { get; set; }
        public byte[] Version { get; set; }

        public virtual Po Pos { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
