using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Data.Repository
{
    public interface IContatosRepository
    {
        ContatosModel BuscarPorId(int id);
        List<ContatosModel> BuscarTodos();
        ContatosModel Adicionar(ContatosModel contatos);
        ContatosModel Atualizar(ContatosModel contatos);
        bool Apagar(int id);

    }
}
