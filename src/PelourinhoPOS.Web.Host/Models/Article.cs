using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Article
    {
        public Article()
        {
            DocLines = new HashSet<DocLine>();
            Pos = new HashSet<Po>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? AskVal { get; set; }
        public string Unity { get; set; }
        public decimal? Weight { get; set; }
        public bool? ForSale { get; set; }
        public bool? IsMenu { get; set; }
        public string Image { get; set; }
        public string IndexColor { get; set; }
        public int? CategoryId { get; set; }
        public int? LevelId { get; set; }
        public string Abbreviation { get; set; }
        public string Priority { get; set; }
        public bool? Active { get; set; }
        public bool? AsWeight { get; set; }
        public int? PosId { get; set; }

        public virtual Category Category { get; set; }
        public virtual CompositeArticle IdNavigation { get; set; }
        public virtual Level Level { get; set; }
        public virtual ArticlePo ArticlePo { get; set; }
        public virtual ICollection<DocLine> DocLines { get; set; }
        public virtual ICollection<Po> Pos { get; set; }
    }
}
