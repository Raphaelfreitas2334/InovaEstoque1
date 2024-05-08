using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using WebApplication1.repositorio;
using WebApplication1.helper;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]
    public class AlterarSenhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                      ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {

                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("index", alterarSenhaModel);
                }

                return View("index", alterarSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel alterar sua senha, por favor tente novamente, detalhe do erro: {erro.Message}";
                return View("index", alterarSenhaModel);
            }
        }

    }
}
