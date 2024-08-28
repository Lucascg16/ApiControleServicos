namespace ApiControleServicos.Domain
{
	public record EmpresaDto
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Cnpj { get; set; }
		public string? Cpf { get; set; }
	}
}
