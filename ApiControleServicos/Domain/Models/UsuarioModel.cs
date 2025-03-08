namespace ApiControleServicos.Domain.Models
{
    public class UsuarioModel : ModelBase
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public int EmpresaId { get; set; }
        public Guid? VId { get; set; } //VId = visual id, pode ser visto na url.
        public bool Dono {  get; set; } = false;

        public UsuarioModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Role = UserRoleEnum.None;
            VId = Guid.Empty;
        }

        public UsuarioModel(string nome, string email, string passWord, UserRoleEnum role, int empresaId, Guid? vId, bool dono)
        {
            Nome = nome;
            Email = email;
            Password = passWord;
            Role = role;
            EmpresaId = empresaId;
            VId = vId;
            Dono = dono;
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

        public void UpdateRole(UserRoleEnum role) 
        {
            Role = role;
        }

        public void Delete()
        {
            Excluir();
        }
    }
}
