using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class CompositeArticle
    {
        public CompositeArticle()
        {
            InverseArticleNavigation = new HashSet<CompositeArticle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? ArticleId { get; set; }
        public byte[] Version { get; set; }

        public virtual CompositeArticle ArticleNavigation { get; set; }
        public virtual Article Article { get; set; }
        public virtual ICollection<CompositeArticle> InverseArticleNavigation { get; set; }
    }
}
