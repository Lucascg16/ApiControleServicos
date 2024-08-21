using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
    public class CreateEmpresaModel
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
    }
}
