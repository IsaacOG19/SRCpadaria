namespace RelacionamentoPadaria.Models
{
    public class ReponsePdfViewModel
    {
        public string Base64 { get; set; } = string.Empty;
        public string ErroDescricao { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
    }
}