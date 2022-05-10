using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class ArticlePo
    {
        public int ArticleId { get; set; }
        public decimal? Pvp1 { get; set; }
        public decimal? Pvp2 { get; set; }
        public decimal? Pvp3 { get; set; }
        public decimal? Pvp4 { get; set; }
        public decimal? Pvp5 { get; set; }
        public decimal? Pvp6 { get; set; }
        public decimal? Pvp7 { get; set; }
        public decimal? Pvp8 { get; set; }
        public decimal? Pvp9 { get; set; }
        public decimal? Pvp10 { get; set; }
        public string Description { get; set; }
        public int? CompositeArticleId { get; set; }
        public int? Iva { get; set; }
        public int PosId { get; set; }
        public byte[] Version { get; set; }
        public int? BarCode { get; set; }

        public virtual Article Article { get; set; }
        public virtual IvaTax IvaNavigation { get; set; }
        public virtual Po Pos { get; set; }
    }
}
