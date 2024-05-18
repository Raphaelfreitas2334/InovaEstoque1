using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

namespace ControleContatos.Repositorio
{
    public interface IFornecimentosRepositorio
    {
        FornecimentosModel Adicionar(FornecimentosModel fornecimentos);
        FornecimentosModel Atualizar(FornecimentosModel fornecimentos);
        FornecimentosModel ObterPorI(int id);
    }
}
