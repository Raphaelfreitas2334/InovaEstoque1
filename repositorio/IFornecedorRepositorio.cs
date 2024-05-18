
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public interface IFornecedorRepositorio
    {
        FornecedorModel ListaPorID(int id);
        FornecedorModel ObterPorI(int id);
        List<FornecedorModel> Consutar();
        FornecedorModel Adicionar(FornecedorModel fornecedor);
        FornecedorModel Atualizar(FornecedorModel fornecedor);
        bool Apagar(int id);

        IEnumerable<FornecedorModel> ObterTodos();
    }
}
