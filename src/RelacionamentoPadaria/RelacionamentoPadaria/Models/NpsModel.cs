using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RelacionamentoPadaria.Models
{
    public class NpsModel
    {
        public int id { get; set; }
        public int Nota { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}