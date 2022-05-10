using Abp.Application.Services.Dto;

namespace PelourinhoPOS.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

