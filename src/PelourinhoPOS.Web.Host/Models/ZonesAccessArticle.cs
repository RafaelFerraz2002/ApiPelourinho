using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class ZonesAccessArticle
    {
        public int? ArticleId { get; set; }
        public int? ZoneId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
