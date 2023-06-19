namespace RelacionamentoPadaria.Data.Entities
{
    public class FeedbackEntity
    {
        public int id { get; set; }
        public int idNota { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Telefone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Observacao { get; set; } = String.Empty;
        public string TipoFeedback { get; set; } = String.Empty;
        public DateTime DataCadastro { get; set; }
    }
}