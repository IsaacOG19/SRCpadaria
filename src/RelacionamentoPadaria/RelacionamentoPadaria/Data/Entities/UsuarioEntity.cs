namespace RelacionamentoPadaria.Data.Entities
{
    public class UsuarioEntity
    {
        public int id { get; set; }
        public bool Ativo { get; set; }
        public bool FicarLogado { get; set; }
        public string? AtivoDescricao { get; set; } = String.Empty;
        public string Nome { get; set; } = String.Empty;
        public string Usuario { get; set; } = String.Empty;
        public string Senha { get; set; } = String.Empty;
        public DateTime DataCadastro { get; set; }
    }
}