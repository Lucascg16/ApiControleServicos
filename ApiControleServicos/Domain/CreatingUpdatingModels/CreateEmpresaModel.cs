using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
    public record CreateEmpresaModel
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
    }
}
