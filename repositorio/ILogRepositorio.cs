using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

namespace ControleContatos.Repositorio
{
    public interface ILogRepositorio
    {
        List<LogsModel> BuscarLogs();
        LogsModel listarPorlogsID(int id);

        LogsModel LogCadastro(LogsModel logsModel);

        LogsModel LogRetirada(LogsModel logsModel);

        LogsModel LogDevolucao(LogsModel logsModel);

    }
}
