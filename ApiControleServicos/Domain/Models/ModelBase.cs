using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleServicos.Domain.Models
{
    public class ModelBase
    {
        [Column(Order = 1)]
        public int Id { get; }
        public bool Excluido { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        public void Excluir()
        {
            Excluido = true;
            Atualizar();
        }

        public void Atualizar()
        {
            DataAtualizacao = DateTime.Now;
        }
    }
}
