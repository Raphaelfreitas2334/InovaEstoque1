using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Filters;
using WebApplication1.helper;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace WebApplication1.Controllers
{
    public class LoginController1 : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController1(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao,
                                IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            //se usuario estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Recadastro()
        {

            return View();
        }

        public IActionResult Inicio()
        {

            return View();
        }

        public IActionResult contact()
        {

            return View();
        }

        public IActionResult projects()
        {

            return View();
        }
        public IActionResult resume()
        {

            return View();
        }


        public IActionResult Sair()
        {
            _sessao.RemoverSessaUsuario();

            return RedirectToAction("index", "LoginController1");

        }

        [HttpPost]
        public IActionResult LoginUsuario(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Email);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            if (usuario.StatusValido(loginModel.Status))
                            {
                                _sessao.CriarSessaoDoUsuario(usuario);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["MensagemErro"] = $"Usuario desativado";
                                return View("Index");
                            }
                        }
                    }

                    TempData["MensagemErro"] = $"Usuario e/ou senha invalidos(s) por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos realizar seu login, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarporEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de Contatos - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o email, por favor verifique tente novamente.";
                        }

                        return RedirectToAction("index", "LoginController1");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos Redefinir sua senha, por favor verifique os dados informados.";
                }

                return View("Recadastro");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos Redefinir sua Senha, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }

}
