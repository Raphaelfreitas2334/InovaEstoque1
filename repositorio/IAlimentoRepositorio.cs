using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

namespace ControleContatos.Repositorio
{
    public interface IAlimentoRepositorio
    {

        AlimentoModel listarPorID(int id);


        List<AlimentoModel> BuscarAlimentos();

        AlimentoModel AdicionarAlimento(AlimentoModel alimento);

        AlimentoModel editarAlimento(AlimentoModel alimento);

        bool excluirAlimento(int id);

        AlimentoModel buscarNomeAlimento(string nomeProduto);

        AlimentoModel gerarSaidaAlimento(AlimentoModel alimento);

        IEnumerable<AlimentoModel> ObterTodos();
    }
}
