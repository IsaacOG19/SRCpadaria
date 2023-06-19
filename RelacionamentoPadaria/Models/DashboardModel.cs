using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RelacionamentoPadaria.Models
{
    public class DashboardModel
    {
        public decimal MediaNps { get; set; }
        public int TotalDenuncias { get; set; }
        public int TotalElogios { get; set; }
        public int TotalSugestoes { get; set; }
        public int TotalReclamacoes { get; set; }
        public List<FeedbackModel> Feedbacks { get; set; } = new List<FeedbackModel>();
        public List<NpsModel> ListaNps { get; set; } = new List<NpsModel>();
    }
}