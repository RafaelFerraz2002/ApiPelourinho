using System.ComponentModel.DataAnnotations;

namespace PelourinhoPOS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}