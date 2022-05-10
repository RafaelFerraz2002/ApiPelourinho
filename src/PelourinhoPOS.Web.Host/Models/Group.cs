using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Group
    {
        public Group()
        {
            Pos = new HashSet<Po>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Po> Pos { get; set; }
    }
}
