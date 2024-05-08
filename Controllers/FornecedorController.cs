using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            List<FornecedorModel> fornecedor = _fornecedorRepositorio.Consutar();
            return View(fornecedor);
        }

        public IActionResult Criar()
        {
            return PartialView("_Criar");
        }

        public IActionResult EditarView(int Id)
        {

            FornecedorModel fornecedor = _fornecedorRepositorio.ListaPorID(Id);

            return PartialView("_EditarView", fornecedor);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListaPorID(Id);
            return PartialView("_ApagarConfirmacao", fornecedor);
        }

        [HttpPost]
        public IActionResult Cadastrar(FornecedorModel fornecedor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    fornecedor = _fornecedorRepositorio.Adicionar(fornecedor);

                    TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Fornecedor nâo cadastrado lenbre-se cadastre todos os Campos ";
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos cadastra o Fornecedor, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", fornecedor);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Atualizar o Fornecedor, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Excluir(int Id)
        {
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Fornecedor Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Fornecedor, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o alimento, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
