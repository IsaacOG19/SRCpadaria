namespace RelacionamentoPadaria.Models
{
    public class EmailMensagemModel
    {
        public List<EmailEnderecoModel> ParaEnderecos { get; set; } = new List<EmailEnderecoModel>();
        public List<EmailEnderecoModel> DeEnderecos { get; set; } = new List<EmailEnderecoModel>();
        public string? Assunto { get; set; }
        public string? Conteudo { get; set; }
    }
}
