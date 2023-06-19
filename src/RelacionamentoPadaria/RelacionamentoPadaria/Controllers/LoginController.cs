using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View(new UsuarioModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(UsuarioModel model)
        {
            model.Validar();
            PreencherModelState("", model.Validacoes);

            if (model.Validacoes.Any())
            {
                PreencherModelState("", model.Validacoes);

                TempData["Status"] = StatusEnum.Alerta;
                TempData["Mensagem"] = MensagemModelInvalido;

                return View(model);
            }

            var result = await _usuarioRepository.Login(model);

            TempData["Status"] = result.Status;
            TempData["Mensagem"] = result.Mensagem;

            if (result.Status == StatusEnum.Sucesso)
                return RedirectToAction("Index", "Dashboard");
            
            model.Senha = String.Empty;

            return View(model);
        }
    }
}
