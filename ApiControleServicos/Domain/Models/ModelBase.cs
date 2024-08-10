namespace ApiControleServicos.Domain.Models
{
    public class ModelBase<TId>
    {
        public ModelBase(TId id)
        {
            Id = id;
        }

        public TId Id { get; set; }
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
