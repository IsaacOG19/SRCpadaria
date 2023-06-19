using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository, 
                                  IRazorViewEngine razorViewEngine,
                                  IServiceProvider serviceProvider,
                                  ITempDataProvider tempDataProvider) : base(razorViewEngine, serviceProvider, tempDataProvider)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            return View(new FeedbackModel());
        }

        [AllowAnonymous]
        public IActionResult ConsultarFeedbacks()
        {
            var result = _feedbackRepository.BuscarFeedbacks();

            TempData["Status"] = result.Status;
            TempData["Mensagem"] = result.Mensagem;

            if (result.Status == StatusEnum.Sucesso)
                return View("Feedbacks", result.Model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalvarFeedback(FeedbackModel model)
        {
            model.Validar();
            PreencherModelState("", model.Validacoes);

            if (model.Validacoes.Any())
            {
                PreencherModelState("", model.Validacoes);

                TempData["Status"] = StatusEnum.Alerta;
                TempData["Mensagem"] = MensagemModelInvalido;
                TempData["ModelInvalido"] = true;

                return View("Index", model);
            }

            var result = _feedbackRepository.SalvarFeedback(model);

            TempData["Status"] = result.Status;
            TempData["Mensagem"] = result.Mensagem;

            if (result.Status == StatusEnum.Sucesso)
                return View("Sucesso");

            return View("Index", model);
        }

        public async Task<IActionResult> ExportarPdf()
        {
            var result = _feedbackRepository.BuscarFeedbacks();

            TempData["Status"] = result.Status;
            TempData["Mensagem"] = result.Mensagem;

            if (result.Status != StatusEnum.Sucesso)
                return RedirectToAction(nameof(Index));

            var html = await ToHtml<FeedbackModel>("Feedback/FeedbacksPDF", result.Model);
            var base64 = await GerarPdf(html);
            var bytes = Convert.FromBase64String(base64);

            return File(bytes, "application/pdf");
        }
    }
}
