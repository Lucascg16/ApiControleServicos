namespace ApiControleServicos.Domain
{
	public class ServicoDto
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public double? Orcamento { get; set; }
		public double? ValorFatudaro { get; set; }
		public double? LucroLiquido{ get; set; }
		public DateTime? DataCriacao { get; set; }
		public DateTime? DataFinalizado	{ get; set; }
	}
}
