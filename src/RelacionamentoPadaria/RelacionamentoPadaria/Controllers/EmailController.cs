using Microsoft.AspNetCore.Mvc;
using RelacionamentoPadaria.Models;
using RelacionamentoPadaria.Services;

namespace RelacionamentoPadaria.Controllers
{
    public class EmailController : Controller
    {
        private IEmailService EmailService;

        public EmailController(IEmailService emailService)
        {
            EmailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContatoEmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMensagemModel msgEnviar = new EmailMensagemModel
                {
                    DeEnderecos = new List<EmailEnderecoModel> { new EmailEnderecoModel { Nome = "Envio de e-mail projeto padaria", Endereco = "pucprojetopadaria@outlook.com" } },
                    ParaEnderecos = new List<EmailEnderecoModel> { new EmailEnderecoModel { Nome = model.Nome, Endereco = model.Email } },

                    Conteudo = $"Mensagem a ser enviada para o cliente: Nome do cliente: {model.Nome}, " +
                               $"{model.Mensagem}",

                    Assunto = "Formulário de contato"
                };

                EmailService.EnviarEmail(msgEnviar);
                return View("RetornoEmail");
            }
            else
            {
                return Index();
            }
        }

        public IActionResult Obrigado()
        {
            return View();
        }
    }
}
