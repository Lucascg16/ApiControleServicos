using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public class UpdateEmpresaModel
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; } = string.Empty;
		public string? Cnpj { get; set; }
		public string? Cpf { get; set; }

	}
}
