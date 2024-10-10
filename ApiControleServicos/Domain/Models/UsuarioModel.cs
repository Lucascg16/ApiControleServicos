namespace ApiControleServicos.Domain.Models
{
    public class UsuarioModel : ModelBase
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "none";
        public int EmpresaId { get; set; }
        public Guid? VId { get; set; } //VId = visual id, pode ser visto na url.

        public UsuarioModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Role = "none";
            VId = Guid.Empty;
        }

        public UsuarioModel(string nome, string email, string passWord, string role, int empresaId, Guid? vId)
        {
            Nome = nome;
            Email = email;
            Password = passWord;
            Role = role;
            EmpresaId = empresaId;
            VId = vId;
        }

        public void UpdateUsuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Atualizar();
        }

        public void UpdateSenha(string pass)
        {
            Password = pass;
            Atualizar();
        }

        public void UpdateRole(string role) 
        {
            Role = role;
        }

        public void Delete()
        {
            Excluir();
        }
    }
}
