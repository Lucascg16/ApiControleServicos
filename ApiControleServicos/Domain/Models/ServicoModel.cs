using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Domain.Models
{
    public class ServicoModel : ModelBase
    {
        public ServicoModel() { }

        public ServicoModel(string? nome, string? descricao, double? custos, double orcamentoInicial, int? usuarioId, int? empresaId)
        {
            Nome = nome;
            Descricao = descricao;
            Custos = custos;
            OrcamentoInicial = orcamentoInicial;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        public string? Nome { get; set; }
        [MaxLength(500)]
        public string? Descricao { get; set; }
        public double? Custos { get; set; }
        public double? OrcamentoInicial { get; set; }
        public double? ValorFaturado { get; set; } = null;
        public double? LucroLiquido { get; set; } = null;
        public DateTime? DataFinalizado { get; set; } = null;
        public ServiceFlagEnum Flag { get; set; } = ServiceFlagEnum.Ativo;
        public int? UsuarioId { get; set; } = 0;
        public int? EmpresaId { get; set; } = 0;

        public void UpdateServico(string nome, string descricao, double orcamento)
        {
            Nome = nome;
            Descricao = descricao;
            Custos = orcamento;
            Atualizar();
        }

        public void FinalizarServico(double faturamento)
        {
			ValorFaturado = faturamento;
			LucroLiquido = faturamento - Custos;
			DataFinalizado = DateTime.Now;
            Flag = ServiceFlagEnum.Finalizado;
			Atualizar();
		}

		public void Deletar()
        {
            Flag = ServiceFlagEnum.Cancelado;
            Excluir();
        }
    }
}
