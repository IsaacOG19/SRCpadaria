using Microsoft.AspNetCore.Mvc;
using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IActionResult Index(DateTime? dataInicio = null, DateTime? dataFim = null)
        {
            dataInicio = dataInicio.HasValue ? dataInicio : TempData["dataInicio"] != null ? (DateTime)TempData["dataInicio"] : null;
            dataFim = dataFim.HasValue ? dataFim : TempData["dataFim"] != null ? (DateTime)TempData["dataFim"] : null;

            TempData["dataInicio"] = dataInicio;
            TempData["dataFim"] = dataFim;

            var result = _dashboardRepository.ObterFeedbacks(dataInicio , dataFim);

            if (result.Status != StatusEnum.Sucesso)
            {
                TempData["Status"] = result.Status;
                TempData["Mensagem"] = result.Mensagem;
            }

            return View(result.Model);
        }
    }
}