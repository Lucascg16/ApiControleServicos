namespace ApiControleServicos.Domain
{
	public class ServicoDto
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public double? Custos { get; set; }
		public double? OrcamentoInicial { get; set; }
		public double? ValorFaturado { get; set; }
		public double? LucroLiquido{ get; set; }
		public bool Exluido { get; set; } = false;
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataFinalizado	{ get; set; }
	}
}
