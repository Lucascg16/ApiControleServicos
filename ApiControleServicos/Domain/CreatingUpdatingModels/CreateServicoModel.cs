using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain.CreatingUpdatingModels
{
	public class CreateServicoModel
	{
		[Required]
		public string Nome { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		[Required]
		public double Orcamento { get; set; }
	}
}
