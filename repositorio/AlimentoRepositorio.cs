using ControleDeContatos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace ControleContatos.Repositorio
{

    public class AlimentoRepositorio : IAlimentoRepositorio
    {
        //essa variavel será usada para dar acesso ao contexto do banco
        //que será utilizada para realizar as operações (CRUD)
        private readonly BancoContext _bancoContext;
        public AlimentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            
        }

        public List<AlimentoModel> BuscarAlimentos()
        {
            //carrega tudo que está no bD
            return _bancoContext.Alimentos.ToList();
        }

        public AlimentoModel AdicionarAlimento(AlimentoModel alimento)
        {
            //gravar no bd 
                // string representando a data no formato AAAA-MM-DD
                string dataOriginal =alimento.dataVencimento.ToString();
                // Converte a string para um objeto DateTime
                DateTime dataConvertida = DateTime.ParseExact(dataOriginal, "yyyy-MM-dd", null);
                // Formata a data no formato DD-MM-AAAA
                string dataFormatada = dataConvertida.ToString("dd-MM-yyyy");
                //joga a data no formato Brasileiro no objeto alimeto
                alimento.dataVencimento = dataFormatada;

                
                alimento.DataCadastro = DateTime.Now;
                _bancoContext.Alimentos.Add(alimento);
                _bancoContext.SaveChanges();
                return alimento;
        }

        public AlimentoModel listarPorID(int id)
        {
            return _bancoContext.Alimentos.FirstOrDefault(a => a.Id == id);
        }


        public AlimentoModel editarAlimento(AlimentoModel alimento)
        {
            AlimentoModel alimentoDB = listarPorID(alimento.Id);
            if (alimentoDB == null) throw new System.Exception("Houve um erro na atualização do alimento");

            alimentoDB.nomeAlimento = alimento.nomeAlimento;
            alimentoDB.dataVencimento = alimento.dataVencimento;
            alimentoDB.unidadeMedida = alimento.unidadeMedida;
            alimentoDB.quantidadeMaxima = alimento.quantidadeMaxima;
            alimentoDB.quantidadeMinima = alimento.quantidadeMinima;
            alimentoDB.quantidadeAtual = alimento.quantidadeAtual;
            alimentoDB.IDusuario = alimento.IDusuario;
            alimentoDB.UsuarioEditou = alimento.UsuarioNome;
            alimentoDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Alimentos.Update(alimentoDB);
            _bancoContext.SaveChanges();

            return alimentoDB;
        }

        public AlimentoModel gerarSaidaAlimento(AlimentoModel alimento)
        {
            //Não está trazendo o ID do alimento
            AlimentoModel alimentoDB = listarPorID(alimento.Id);
            if (alimentoDB == null) throw new System.Exception("Houve um erro ao gerar a saida do alimento");
            
            alimentoDB.IDusuario = alimento.IDusuario;
            if (alimento.quantidadeRetirada > alimentoDB.quantidadeAtual) throw new System.Exception("Não pode retirar mais do que tem no estoque");
            alimentoDB.quantidadeAtual = alimentoDB.quantidadeAtual - alimento.quantidadeRetirada;
            alimentoDB.quantidadeRetirada = alimento.quantidadeRetirada;
            alimentoDB.DataRetira = DateTime.Now;
            alimentoDB.UsuarioRetirou = alimento.UsuarioNome;
            alimentoDB.obsDeSaida = alimento.obsDeSaida;

            _bancoContext.Alimentos.Update(alimentoDB);
            _bancoContext.SaveChanges();
            return alimentoDB;
        }

        public bool excluirAlimento(int id)
        {
            AlimentoModel alimentoDB = listarPorID(id);
            if (alimentoDB == null) throw new System.Exception("Houve um erro na atualização do alimento");
            
            _bancoContext.Alimentos.Remove(alimentoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public AlimentoModel buscarNomeAlimento(string nomeProduto)
        {
            return _bancoContext.Alimentos.FirstOrDefault(x => x.nomeAlimento == nomeProduto);
        }

        public IEnumerable<AlimentoModel> ObterTodos()
        {
            return _bancoContext.Alimentos.ToList();
        }
    }
}
