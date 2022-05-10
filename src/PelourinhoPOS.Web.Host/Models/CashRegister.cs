using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class CashRegister
    {
        public CashRegister()
        {
            DocHeaders = new HashSet<DocHeader>();
        }

        public int Id { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? OpenHour { get; set; }
        public DateTime? CloseHour { get; set; }
        public decimal? StartValue { get; set; }
        public decimal? FinalValue { get; set; }
        public decimal? Value { get; set; }
        public decimal? ValueTax { get; set; }
        public bool? Closed { get; set; }
        public string DayBilling { get; set; }
        public string PosName { get; set; }
        public byte[] Version { get; set; }

        public virtual ICollection<DocHeader> DocHeaders { get; set; }
    }
}
