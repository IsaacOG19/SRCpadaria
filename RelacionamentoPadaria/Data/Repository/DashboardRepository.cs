using RelacionamentoPadaria.Enums;
using RelacionamentoPadaria.Models;
using RelacionamentoPadaria.Data.Context;

namespace RelacionamentoPadaria.Data.Repository
{
    public interface IDashboardRepository
    {
        ResultModel<DashboardModel> ObterFeedbacks(DateTime? dataInicio = null, DateTime? dataFim = null);
    }

    public class DashboardRepository : BaseRepository, IDashboardRepository
    {
        protected DatabaseContext _db { get; set; }

        public DashboardRepository(DatabaseContext db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
        }

        public ResultModel<DashboardModel> ObterFeedbacks(DateTime? dataInicio = null, DateTime? dataFim = null)
        {
            var result = new ResultModel<DashboardModel>();

            try
            {
                result.Model.Feedbacks = (from feedback in _db.Feedbacks
                                          where feedback.DataCadastro >= (dataInicio ?? DateTime.Today.AddYears(-200))
                                                && feedback.DataCadastro <= (dataFim ?? DateTime.Today.AddYears(200))
                                          select new FeedbackModel()
                                          {
                                              id = feedback.id,
                                              TipoFeedback = feedback.TipoFeedback,
                                              idNota = feedback.idNota
                                          }).ToList();

                result.Model.ListaNps = (from nps in _db.Nps
                                         where nps.DataCadastro >= (dataInicio ?? DateTime.Today.AddYears(-200))
                                               && nps.DataCadastro <= (dataFim ?? DateTime.Today.AddYears(200))
                                         select new NpsModel()
                                         {
                                             id = nps.id,
                                             Nota = nps.Nota
                                         }).ToList();

                decimal somaNps = result.Model.ListaNps.Sum(x => x.Nota);
                decimal totalNps = result.Model.ListaNps.Count();
                if (totalNps > 0)
                    result.Model.MediaNps = somaNps / totalNps;
                result.Model.TotalReclamacoes = result.Model.Feedbacks.Count(x => x.TipoFeedback == "Reclamação");
                result.Model.TotalSugestoes = result.Model.Feedbacks.Count(x => x.TipoFeedback == "Sugestão");
                result.Model.TotalDenuncias = result.Model.Feedbacks.Count(x => x.TipoFeedback == "Denúncia");
                result.Model.TotalElogios = result.Model.Feedbacks.Count(x => x.TipoFeedback == "Elogio");

                result.Status = StatusEnum.Sucesso;
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
