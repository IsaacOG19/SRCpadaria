using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelacionamentoPadaria.Data.Context;
using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatosRepository _contatosRepository;
        public ContatoController(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }

        // GET: ContatosController
        public IActionResult Index()
        {
            List<ContatosModel> contatos = _contatosRepository.BuscarTodos();
            return View(contatos);
        }

        // GET: ContatosController/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // GET: ContatosController/Edit/5
        public IActionResult Editar(int id)
        {
            ContatosModel contatos = _contatosRepository.BuscarPorId(id);
            return View(contatos);
        }

        // GET: ContatosController/Delete/5
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatosModel contatos = _contatosRepository.BuscarPorId(id);
            return View(contatos);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatosRepository.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatosModel contatos)
        {
            _contatosRepository.Adicionar(contatos);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatosModel contatos)
        {
            _contatosRepository.Atualizar(contatos);
            return RedirectToAction("Index");
        }
    }
}
