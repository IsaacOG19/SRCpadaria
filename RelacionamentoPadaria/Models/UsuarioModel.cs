using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RelacionamentoPadaria.Models
{
    public class UsuarioModel : BaseModel
    {
        public int id { get; set; }
        public bool Ativo { get; set; }
        public bool FicarLogado { get; set; }
        public string? AtivoDescricao { get; set; } = String.Empty;
        public string Nome { get; set; } = String.Empty;
        public string Usuario { get; set; } = String.Empty;
        public string Senha { get; set; } = String.Empty;

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Usuario) && id == 0)
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Usuario), Mensagem = "Favor preencher o E-mail" });
            }
            if (String.IsNullOrEmpty(Senha) && id == 0)
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Senha), Mensagem = "Favor preencher a senha" });
            }
        }
    }
}