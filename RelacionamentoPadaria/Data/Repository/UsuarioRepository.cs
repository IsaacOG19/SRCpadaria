using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;
using System.Security.Claims;
using System.Text;
using RelacionamentoPadaria.Data.Context;

namespace RelacionamentoPadaria.Data.Repository
{
    public interface IUsuarioRepository
    {
        Task<ResultModel<UsuarioModel>> Login(UsuarioModel model);
    }

    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        protected DatabaseContext _db { get; set; }
        private readonly IHttpContextAccessor _httpContext;

        public UsuarioRepository(DatabaseContext db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
            _httpContext = httpContext;
        }

        public async Task<ResultModel<UsuarioModel>> Login(UsuarioModel model)
        {
            var result = new ResultModel<UsuarioModel>();

            try
            {
                result.Model = (from usuario in _db.Usuarios
                                where usuario.Usuario == model.Usuario && usuario.Senha == model.Senha
                                select new UsuarioModel()
                                {
                                    id = usuario.id,
                                    Nome = usuario.Nome,
                                    Usuario = usuario.Usuario,
                                    Ativo = usuario.Ativo,
                                }).FirstOrDefault() ?? new UsuarioModel();

                if (result.Model.id == 0)
                {
                    result.Status = StatusEnum.Alerta;
                    result.Mensagem = MensagemInformacoesIncorretas;
                }
                else if (!result.Model.Ativo)
                {
                    result.Status = StatusEnum.Alerta;
                    result.Mensagem = MensagemUsuarioInativo;
                }
                else
                {
                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, result.Model.Nome));
                    claims.Add(new Claim("Id", result.Model.id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, result.Model.Usuario));
                    claims.Add(new Claim(ClaimTypes.Sid, result.Model.id.ToString()));

                    var claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                    var authProperties = new AuthenticationProperties
                    {
                        IssuedUtc = DateTime.Now,
                        ExpiresUtc = model.FicarLogado ? DateTime.Now.AddYears(1) : DateTime.Now.AddHours(8),
                        IsPersistent = model.FicarLogado
                    };

                    await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);

                    result.Status = StatusEnum.Sucesso;
                    result.Mensagem = MensagemSucessoLogin;
                }
            }
            catch (Exception e)
            {
                result.Status = StatusEnum.Erro;
                result.Mensagem = MensagemErro;
            }

            return result;
        }
    }
}
