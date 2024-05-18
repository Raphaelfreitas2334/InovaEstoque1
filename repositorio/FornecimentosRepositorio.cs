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

    public class FornecimentosRepositorio : IFornecimentosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public FornecimentosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

        public FornecimentosModel Adicionar(FornecimentosModel fornecimentos)
        {
            _bancoContext.Fornecimentos.Add(fornecimentos);
            _bancoContext.SaveChanges();
            return fornecimentos;
        }

        public FornecimentosModel Atualizar(FornecimentosModel fornecimentos)
        {
            FornecimentosModel fornecimentosDB = ObterPorI(fornecimentos.IdAlimento);
            if (fornecimentosDB == null) throw new System.Exception("Houve um erro na atualização do alimento");

            fornecimentosDB.IdAlimento = fornecimentos.IdAlimento;
            fornecimentosDB.NomeAlimento = fornecimentos.NomeAlimento;
            fornecimentosDB.DataVencimento = fornecimentos.DataVencimento;
            fornecimentosDB.UnidadeMedida = fornecimentos.UnidadeMedida;
            fornecimentosDB.QuantidadeFornecida = fornecimentos.QuantidadeFornecida;

            _bancoContext.Fornecimentos.Update(fornecimentosDB);
            _bancoContext.SaveChanges();

            return fornecimentosDB;
        }

        public FornecimentosModel ObterPorI(int id)
        {
            // Consultar o fornecedor pelo ID usando LINQ
            var fornecedor = _bancoContext.Fornecimentos.FirstOrDefault(f => f.Id == id);

            return fornecedor; // Retorna o fornecedor encontrado ou null se não for encontrado
        }
    }
}
