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

        public UsuarioModel(string nome, string email, int empresaId)
        {
            Nome = nome;
            Email = email;
            EmpresaId = empresaId;
        }

        public void UpdateUsuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Atualizar();
        }

        public void Delete()
        {
            Excluir();
        }
    }
}
