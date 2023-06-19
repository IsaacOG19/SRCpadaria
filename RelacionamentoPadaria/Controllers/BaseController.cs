using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using RelacionamentoPadaria.Models;
using System.Text;

namespace RelacionamentoPadaria.Controllers
{
    public abstract class BaseController : Controller
    {
        protected const string MensagemModelInvalido = "Favor preencher todos os campos corretamente";
        protected const string MensagemErroProcessamento = "Houve erro durante o processamento";

        private IRazorViewEngine _razorViewEngine;
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;

        public BaseController(IRazorViewEngine razorViewEngine = null,
                              IServiceProvider serviceProvider = null,
                              ITempDataProvider tempDataProvider = null)
        {
            _razorViewEngine = razorViewEngine;
            _serviceProvider = serviceProvider;
            _tempDataProvider = tempDataProvider;
        }

        protected void PreencherModelState(string NomeModel, List<ValidacaoModel> validacoes, bool limparModelState = true)
        {
            if (limparModelState)
            {
                ModelState.Clear();
            }

            foreach (var validacao in validacoes)
            {
                var key = String.Empty;
                if (String.IsNullOrEmpty(NomeModel))
                    key = validacao.Campo;
                else
                    key = $"{NomeModel}.{validacao.Campo}";

                ModelState.AddModelError(key, validacao.Mensagem);
            }
        }

        protected async Task<string> ToHtml<T>(string viewName, T model) where T : class, new()
        {
            var httpContext = new DefaultHttpContext()
            {
                RequestServices = _serviceProvider
            };
            var actionContext = new ActionContext(
                    httpContext, new RouteData(), new ActionDescriptor());

            using (StringWriter sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(
                        actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    return string.Empty;
                }

                var metadataProvider = new EmptyModelMetadataProvider();
                var msDictionary = new ModelStateDictionary();
                var viewDataDictionary = new ViewDataDictionary(metadataProvider, msDictionary);

                viewDataDictionary.Model = model;

                var tempDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
                var viewContext = new ViewContext(
                                  actionContext,
                                  viewResult.View,
                                  viewDataDictionary,
                                  tempDictionary,
                                  sw,
                                  new HtmlHelperOptions()
                              );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }

            return String.Empty;
        }

        public async Task<string> GerarPdf(string html, bool landScape = false)
        {
            string base64 = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var model = new { html = html };

                client.DefaultRequestHeaders.Add("api-token", "kTSe6XgysU2QQfFLK/AgqA==");
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://azfn-api-html2pdf.azurewebsites.net/api/html2pdf?code=AtNZUV9zpmNXKiku8GH7xjnMQnknZf0iA5tqE/6ekB5Oo8PdN6nlEQ==", content);

                var responseModel = JsonConvert.DeserializeObject<ReponsePdfViewModel>(await response.Content.ReadAsStringAsync());

                if (!String.IsNullOrEmpty(responseModel.Base64))
                    base64 = responseModel.Base64;
            }
            return base64;
        }
    }
}
