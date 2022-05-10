using Abp.AutoMapper;
using PelourinhoPOS.Authentication.External;

namespace PelourinhoPOS.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
