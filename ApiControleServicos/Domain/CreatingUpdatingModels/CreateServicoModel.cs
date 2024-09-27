using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain
{
	public record CreateServicoModel
	{
		[Required]
		public string Nome { get; set; } = string.Empty;
		public string Descricao { get; set; } = string.Empty;
		[Required]
		public double Custos { get; set; }
		[Required]
		public double OrcamentoInicial { get; set; }
		[Required]
		public int UsuarioId { get; set; }
		[Required]
		public int EmpresaId { get; set; }
	}
}
