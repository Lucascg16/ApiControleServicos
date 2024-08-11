namespace ApiControleServicos.Domain.Models
{
    public class ServicoModel : ModelBase
    {
        public string? Nome { get; set; } = null;
        public string? Descricao { get; set; } = null;
        public double? Orcamento { get; set; } = null;
        public double? ValorFaturado { get; set; } = null;
        public double? LucroLiquido { get; set; } = null;
        public DateTime? DataFinalizado { get; set; } = null;
        public int? UsuarioId { get; set; } = 0;
        public int? EmpresaId { get; set; } = 0;

        public ServicoModel(string? nome, string? descricao, double? orcamento, double? valorFaturado,
            double? lucroLiquido, DateTime? finalizado, int? usuarioId, int? empresaId)
        {
            Nome = nome;
            Descricao = descricao;
            Orcamento = orcamento;
            ValorFaturado = valorFaturado;
            LucroLiquido = lucroLiquido;
            DataFinalizado = finalizado;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        public static ServicoModel Create(string? nome, string? descricao, double? orcamento, double? valorFaturado,
            double? lucroLiquido, DateTime? finalizado, int? usuarioId, int? empresaId) =>
            new(nome:nome, descricao:descricao, orcamento: orcamento, valorFaturado:valorFaturado, lucroLiquido:lucroLiquido,
                finalizado: finalizado, usuarioId:usuarioId, empresaId:empresaId);

        public void Deletar()
        {
            Excluir();
        }
    }
}
