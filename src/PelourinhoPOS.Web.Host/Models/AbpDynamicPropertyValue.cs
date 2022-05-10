using System;
using System.Collections.Generic;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class AbpDynamicPropertyValue
    {
        public string Value { get; set; }
        public int? TenantId { get; set; }
        public int DynamicPropertyId { get; set; }
        public long Id { get; set; }

        public virtual AbpDynamicProperty DynamicProperty { get; set; }
    }
}
