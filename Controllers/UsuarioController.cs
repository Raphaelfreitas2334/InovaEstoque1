using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Filters;
using WebApplication1.helper;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _UsuarioRepositorio.BuscaTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return PartialView("_Criar");
        }

        public IActionResult Editar(int Id)
        {

            UsuarioModel usuario = _UsuarioRepositorio.ListaPorID(Id);
            return PartialView("_Editar", usuario);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.ListaPorID(Id);
            return PartialView("_ApagarConfirmacao", usuario);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _UsuarioRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Usuario, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o Usuario, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario1 = _UsuarioRepositorio.BuscarPorLogin(usuario.Email);
                    // Verifica se o e-mail já existe no banco de dados
                    if (usuario1 == null)
                    {
                        usuario = _UsuarioRepositorio.Adicionar(usuario);
                        TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "E-mail já está em uso";
                        return RedirectToAction("Index");
                    }

                }
                TempData["MensagemErro"] = "Preencha todos os campo corretamentes";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos cadastra o Usuario, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsusarioSemSenhaModel ususarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = ususarioSemSenhaModel.Id,
                        NomeUsuario = ususarioSemSenhaModel.NomeUsuario,
                        Email = ususarioSemSenhaModel.Email,
                        Login = ususarioSemSenhaModel.Login,
                        Funcao = ususarioSemSenhaModel.Funcao,
                        Ativo = ususarioSemSenhaModel.Ativo
                    };

                    _UsuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Atualizar o Usuario, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}