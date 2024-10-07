namespace ApiControleServicos.Domain
{
	public record ServicoDto
	{
		public int Id { get; set; }
		public int EmpresaId { get; set; }
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public double? Custos { get; set; }
		public double? OrcamentoInicial { get; set; }
		public double? ValorFaturado { get; set; }
		public double? LucroLiquido{ get; set; }
		public bool Excluido { get; set; }
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataFinalizado	{ get; set; }
	}
}
