using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class Access
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? LevelId { get; set; }

        public virtual Level Level { get; set; }
    }
}
