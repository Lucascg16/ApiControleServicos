using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public record UpdateServicoModel
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; } = string.Empty;
		[Required]
		public string Descricao {  get; set; } = string.Empty;
		[Required]
		public double Custos { get; set; }
	}
}
