using ControleDeContatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _Context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string Email)
        {
            return _Context.Usuario.FirstOrDefault(X => X.Email.ToUpper() == Email.ToUpper());
        }
        public UsuarioModel BuscarporEmailELogin(string email, string login)
        {
            return _Context.Usuario.FirstOrDefault(X => X.Email.ToUpper() == email.ToUpper() && X.Login.ToUpper() == login.ToUpper() )  ;
        }
        public UsuarioModel ListaPorID(int id)
        {
            return _Context.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscaTodos()
        {
            return _Context.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataLogin = DateTime.Now;
            usuario.SetSenhaHash();
            _Context.Usuario.Add(usuario);
            _Context.SaveChanges();
            return usuario;

        }

        public List<UsuarioModel> BuscaTodos(int id)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            //aqui esta buscando  pelo Id
            UsuarioModel usuarioDB = ListaPorID(usuario.Id);
            // esse e um if para ver se o id esta fazio se sem mostra o erro abaixo
            if (usuarioDB == null) throw new System.Exception("Houve um erro na Atualização do Usuario!");
            //aqui estamos setando os falores nos campos respectivos no banco de dados
            usuarioDB.NomeUsuario = usuario.NomeUsuario;
            usuarioDB.Funcao = usuario.Funcao;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAtualizacao = DateTime.Now;
            usuarioDB.Ativo = usuario.Ativo;

             //mandadno os dados para o banco
                _Context.Usuario.Update(usuarioDB);
            _Context.SaveChanges();

            // Agora, atualize cada Fornecimento relacionado
            var Logs = _Context.Logs.Where(f => f.IdUsuario == usuario.Id).ToList();

            foreach (var log in Logs)
            {
                if(log.UsuarioCadastrou != null)
                {
                    log.UsuarioCadastrou = usuario.NomeUsuario;
                }
                if(log.UsuarioDevolvel != null)
                {
                    log.UsuarioDevolvel = usuario.NomeUsuario;
                }
                if(log.UsuarioEditou != null)
                {
                    log.UsuarioEditou = usuario.NomeUsuario;
                }
                if(log.UsuarioRetirou != null)
                {
                    log.UsuarioRetirou = usuario.NomeUsuario;
                }
                if(log.UsuarioRemovel != null)
                {
                    log.UsuarioRemovel = usuario.NomeUsuario;
                }
            }

            _Context.SaveChanges();
            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListaPorID(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização da senha, usuario não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new System.Exception("Senha atual não confere");

            if (usuarioDB.SenhaValida(alterarSenhaModel.ConfirmarSenha)) throw new System.Exception("Nova senha deve ser diferente da senha atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _Context.Usuario.Update(usuarioDB);
            _Context.SaveChanges();

            return usuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListaPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleçaõ do Usuario!");

            _Context.Usuario.Remove(usuarioDB);
            _Context.SaveChanges();

            return true;
        }

       
    }
}
