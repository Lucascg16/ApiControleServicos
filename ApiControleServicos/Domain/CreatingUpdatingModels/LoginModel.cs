using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
    public record LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
