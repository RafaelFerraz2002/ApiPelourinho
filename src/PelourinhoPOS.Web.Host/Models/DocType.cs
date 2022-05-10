using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class DocType
    {
        public DocType()
        {
            DocHeaders = new HashSet<DocHeader>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? Counter { get; set; }
        public bool? Active { get; set; }
        public string Printer { get; set; }
        public string ValueType { get; set; }

        public virtual ICollection<DocHeader> DocHeaders { get; set; }
    }
}
