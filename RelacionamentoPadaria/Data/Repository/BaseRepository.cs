using System.Security.Claims;

namespace RelacionamentoPadaria.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly HttpContext HttpContext;
        protected readonly ClaimsPrincipal User;
        protected readonly int IdUsuarioSessao;

        protected string MensagemErro = "Houve erro no processamento";
        protected string MensagemSucessoLogin = "Login realizado com sucesso";
        protected string MensagemUsuarioInativo = "Usuário inativo";
        protected string MensagemInformacoesIncorretas = "Usuário ou senha incorretos";
        protected string MensagemFeedbackSucesso = "Feedback salvo com sucesso";

        public BaseRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            HttpContext = _httpContextAccessor.HttpContext;
            User = HttpContext.User;

            IdUsuarioSessao = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value ?? "0");
        }
    }
}
