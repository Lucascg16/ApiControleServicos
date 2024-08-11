namespace ApiControleServicos.Domain.Models
{
    public class UsuarioModel : ModelBase
    {
        public string? Nome { get; set; }//TODO: Add mensagens de erro quando necessario
        public string? Email { get; set; }
        public int EmpresaId { get; set; }

        public UsuarioModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
        }

        private UsuarioModel(string nome, string email, int empresaId)
        {
            Nome = nome;
            Email = email;
            EmpresaId = empresaId;
        }

        public static UsuarioModel Create(string nome, string email, int empresaId) => 
            new (nome: nome, email: email, empresaId:empresaId);

        public void Delete()
        {
            Excluir();
        }
    }
}
