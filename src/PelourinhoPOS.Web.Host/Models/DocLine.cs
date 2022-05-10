using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class DocLine
    {
        public DocLine()
        {
            Pos = new HashSet<Po>();
        }

        public int Id { get; set; }
        public decimal? SubtotalNoIva { get; set; }
        public decimal? IvaTax { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? SubtotalIva { get; set; }
        public int? ArticleId { get; set; }
        public int? DocHeaderId { get; set; }
        public int? MenuId { get; set; }
        public int? PosId { get; set; }

        public virtual Article Article { get; set; }
        public virtual DocHeader DocHeader { get; set; }
        public virtual ICollection<Po> Pos { get; set; }
    }
}
