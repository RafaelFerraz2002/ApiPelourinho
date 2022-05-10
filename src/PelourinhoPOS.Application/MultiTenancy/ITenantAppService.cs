using Abp.Application.Services;
using PelourinhoPOS.MultiTenancy.Dto;

namespace PelourinhoPOS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

