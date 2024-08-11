using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleServicos.Domain.Models
{
    public class ModelBase
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order = 100)]
        public bool Excluido { get; set; } = false;
        [Column(Order = 101)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [Column(Order = 102)]
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
