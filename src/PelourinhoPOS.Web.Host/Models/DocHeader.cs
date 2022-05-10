using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class DocHeader
    {
        public DocHeader()
        {
            DocLines = new HashSet<DocLine>();
        }

        public int Id { get; set; }
        public int? CostumerId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public int? UserId { get; set; }
        public int? DocTypeId { get; set; }
        public int? ZoneId { get; set; }
        public int? BoardId { get; set; }
        public string PaymentMethod { get; set; }
        public int? CashRegisterId { get; set; }

        public virtual Board Board { get; set; }
        public virtual CashRegister CashRegister { get; set; }
        public virtual Customer Costumer { get; set; }
        public virtual DocType DocType { get; set; }
        public virtual User User { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual ICollection<DocLine> DocLines { get; set; }
    }
}
