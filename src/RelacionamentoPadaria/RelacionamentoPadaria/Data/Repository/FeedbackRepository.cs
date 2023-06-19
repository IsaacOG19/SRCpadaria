using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;
using System.Security.Claims;
using System.Text;
using RelacionamentoPadaria.Data.Entities;
using RelacionamentoPadaria.Data.Context;

namespace RelacionamentoPadaria.Data.Repository
{
    public interface IFeedbackRepository
    {
        ResultModel<FeedbackModel> SalvarFeedback(FeedbackModel model);
        ResultModel<FeedbackModel> BuscarFeedbacks();
    }

    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        protected DatabaseContext _db { get; set; }

        public FeedbackRepository(DatabaseContext db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
        }

        public ResultModel<FeedbackModel> BuscarFeedbacks()
        {
            var result = new ResultModel<FeedbackModel>();

            try
            {
                result.Model.Feedbacks = (from feedback in _db.Feedbacks
                                          join nps in _db.Nps on feedback.idNota equals nps.id
                                          select new FeedbackModel()
                                          {
                                              id = feedback.id,
                                              idNota = feedback.idNota,
                                              Nome = feedback.Nome,
                                              Email = feedback.Email,
                                              Telefone = feedback.Telefone,
                                              Observacao = feedback.Observacao,
                                              TipoFeedback = feedback.TipoFeedback,
                                              DataCadastro = feedback.DataCadastro,
                                              Nota = nps.Nota
                                          }).ToList();

                result.Status = StatusEnum.Sucesso;
            }
            catch (Exception e)
            {
                result.Status = StatusEnum.Erro;
                result.Mensagem = MensagemErro;
            }

            return result;
        }

        public ResultModel<FeedbackModel> SalvarFeedback(FeedbackModel model)
        {
            var result = new ResultModel<FeedbackModel>();

            try
            {
                var NpsEntity = new NpsEntity()
                {
                    Nota = model.Nota,
                    DataCadastro = DateTime.Today
                };
                _db.Add(NpsEntity);
                _db.SaveChanges();

                if (!String.IsNullOrEmpty(model.TipoFeedback))
                {
                    var feedbackEntity = new FeedbackEntity()
                    {
                        Nome = model.Nome,
                        Telefone = model.Telefone,
                        Email = model.Email,
                        idNota = NpsEntity.id,
                        Observacao = model.Observacao,
                        TipoFeedback = model.TipoFeedback.Replace(" ", "").Replace("\r\n", ""),
                        DataCadastro = DateTime.Today
                    };
                    _db.Add(feedbackEntity);
                    _db.SaveChanges();
                }

                result.Status = StatusEnum.Sucesso;
                result.Mensagem = MensagemFeedbackSucesso;
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