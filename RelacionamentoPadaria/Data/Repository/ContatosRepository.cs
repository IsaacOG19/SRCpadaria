using RelacionamentoPadaria.Data.Context;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Data.Repository
{
    public class ContatosRepository : BaseRepository, IContatosRepository
    {
        private readonly DatabaseContext _db;
        private readonly IHttpContextAccessor _httpContext;

        public ContatosRepository(DatabaseContext db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
            _httpContext = httpContext;
        }

        public ContatosModel BuscarPorId(int id)
        {
            return _db.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatosModel> BuscarTodos()
        {
            return _db.Contatos.ToList();
        }

        public ContatosModel Adicionar(ContatosModel contatos)
        {
            _db.Contatos.Add(contatos);
            _db.SaveChanges();

            return contatos;
        }

        public ContatosModel Atualizar(ContatosModel contatos)
        {
            ContatosModel contatoDB = BuscarPorId(contatos.Id);

            if (contatos == null) throw new Exception("Houve um erro na atualização do contato!");

            contatoDB.Id = contatos.Id;
            contatoDB.Nome = contatos.Nome;
            contatoDB.Email = contatos.Email;
            contatoDB.Telefone = contatos.Telefone;
            contatoDB.RedesSociais = contatos.RedesSociais;
            contatoDB.Observacao = contatos.Observacao;
            contatoDB.Status = contatos.Status;
            contatoDB.DataCadastro = contatos.DataCadastro;

            _db.Contatos.Update(contatoDB);
            _db.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatosModel contatoDB = BuscarPorId(id);

            if (contatoDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _db.Contatos.Remove(contatoDB);
            _db.SaveChanges();

            return true;
        }
    }
}
