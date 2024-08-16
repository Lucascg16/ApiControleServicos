namespace ApiControleServicos.Domain.Models
{
    public class ServicoModel : ModelBase
    {
        public ServicoModel(string? nome, string? descricao, double? orcamento, double? valorFaturado, double? lucroLiquido,
            DateTime? dataFinalizado, int? usuarioId, int? empresaId)
        {
            Nome = nome;
            Descricao = descricao;
            Orcamento = orcamento;
            ValorFaturado = valorFaturado;
            LucroLiquido = lucroLiquido;
            DataFinalizado = dataFinalizado;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Orcamento { get; set; }
        public double? ValorFaturado { get; set; }
        public double? LucroLiquido { get; set; }
        public DateTime? DataFinalizado { get; set; }
        public int? UsuarioId { get; set; } = 0;
        public int? EmpresaId { get; set; } = 0;


        public void Deletar()
        {
            Excluir();
        }
    }
}
