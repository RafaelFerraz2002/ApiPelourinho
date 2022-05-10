using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Level
    {
        public Level()
        {
            Accesses = new HashSet<Access>();
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Access> Accesses { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
