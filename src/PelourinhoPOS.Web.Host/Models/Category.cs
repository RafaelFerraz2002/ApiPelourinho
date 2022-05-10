using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            InverseCategoryNavigation = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public bool? Active { get; set; }
        public byte[] Version { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Category> InverseCategoryNavigation { get; set; }
    }
}
