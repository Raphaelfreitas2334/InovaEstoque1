using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;
using WebApplication1.helper;


namespace WebApplication1.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "Informe o perfil do Usuario")]
        public PerfilEnum? Funcao { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }

        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        public DateTime DataLogin { get; set; }
        //a "?" dis que o campo pode ser null
        public DateTime? DataAtualizacao { get; set; }

        public Boolean Ativo { get; set; }

        public virtual List<AlimentoModel> Alimento { get; set; }

        public bool SenhaValida(String senha)
        {
            return Senha == senha.GerarHash();
        }

        public bool StatusValido(Boolean ativo)
        {
            return Ativo;
        }

        //metodo para setar a senha e criar um hash
        public void SetSenhaHash()
        {
            //isso e um metodo de extenção que esta ligado a criptografia pelo "this"
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            //isso e um metodo de extenção que esta ligado a criptografia pelo "this"
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            //aqui ele esta gerando uma nova senha de 0 ate 8 na Guid
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            //nessa linha esta pegando a nova senha gerada e gerando em hash com ela e colocando ela em nova senha
            Senha = novaSenha.GerarHash();
            //retornando a senha sem gerar o Hash
            return novaSenha;
        }
    }
}