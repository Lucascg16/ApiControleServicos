namespace ApiControleServicos.Domain.Models
{
    public class ServicoModel : ModelBase
    {
        public string? Nome { get; set; } = null;
        public string? Descricao { get; set; } = null;
        public double? Orcamento { get; set; } = null;
        public double? ValorFaturado { get; set; } = null;
        public double? LucroLiquido { get; set; } = null;
        public DateTime? Inicio { get; set; } 
        public DateTime? Termino { get; set; }
        public int? UsuarioId { get; set; }
        public int? EmpresaId { get; set; }

        public ServicoModel() { }

        public ServicoModel(string? nome, string? descricao, double? orcamento, double? valorFaturado,
            double? lucroLiquido, DateTime? inicio, DateTime? termino, int? usuarioId, int? empresaId)
        {
            Nome = nome;
            Descricao = descricao;
            Orcamento = orcamento;
            ValorFaturado = valorFaturado;
            LucroLiquido = lucroLiquido;
            Inicio = inicio;
            Termino = termino;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        public static ServicoModel Create(string? nome, string? descricao, double? orcamento, double? valorFaturado,
            double? lucroLiquido, DateTime? inicio, DateTime? termino, int? usuarioId, int? empresaId) =>
            new(nome:nome, descricao:descricao, orcamento: orcamento, valorFaturado:valorFaturado, lucroLiquido:lucroLiquido,
                inicio:inicio, termino: termino,usuarioId:usuarioId, empresaId:empresaId);

        public void Deletar()
        {
            Excluir();
        }
    }
}
