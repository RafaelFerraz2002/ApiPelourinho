using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class IvaTax
    {
        public IvaTax()
        {
            ArticlePos = new HashSet<ArticlePo>();
        }

        public int Id { get; set; }
        public decimal? Tax { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<ArticlePo> ArticlePos { get; set; }
    }
}
