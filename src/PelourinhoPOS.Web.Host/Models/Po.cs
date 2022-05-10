using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Po
    {
        public Po()
        {
            ArticlePos = new HashSet<ArticlePo>();
            CustomerPos = new HashSet<CustomerPo>();
            Grupos = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; }
        public int? AccesLevelId { get; set; }
        public int? UserId { get; set; }
        public int? ZoneId { get; set; }
        public int? CustomerId { get; set; }
        public int? ArticleId { get; set; }
        public int? DocLinesId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DocLine DocLines { get; set; }
        public virtual User User { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual ICollection<ArticlePo> ArticlePos { get; set; }
        public virtual ICollection<CustomerPo> CustomerPos { get; set; }

        public virtual ICollection<Group> Grupos { get; set; }
    }
}
