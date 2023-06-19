using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RelacionamentoPadaria.Models
{
    public class FeedbackModel : BaseModel
    {
        public int id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Telefone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Observacao { get; set; } = String.Empty;
        public int Nota { get; set; }
        public int idNota { get; set; }
        public string TipoFeedback { get; set; } = String.Empty;
        public DateTime DataCadastro { get; set; }
        public List<FeedbackModel> Feedbacks { get; set; } = new List<FeedbackModel>();

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(TipoFeedback))
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Nome), Mensagem = "Favor preencher o Nome" });
            }
            if (String.IsNullOrEmpty(Telefone) && !String.IsNullOrEmpty(TipoFeedback))
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Telefone), Mensagem = "Favor preencher o Telefone" });
            }
            if (String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(TipoFeedback))
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Email), Mensagem = "Favor preencher o E-mail" });
            }
            if (String.IsNullOrEmpty(Observacao) && !String.IsNullOrEmpty(TipoFeedback))
            {
                Validacoes.Add(new ValidacaoModel { Campo = nameof(Observacao), Mensagem = "Favor preencher" });
            }
        }
    }
}