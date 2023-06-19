namespace RelacionamentoPadaria.Data.Entities
{
    public class ContatosEntity
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; } 
        public string? Email { get; set; } 
        public string? Observacao { get; set; }
        public string? RedesSociais { get; set; } 
        public bool Status { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
