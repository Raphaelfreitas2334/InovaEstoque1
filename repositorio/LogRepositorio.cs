using ControleDeContatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;


namespace ControleContatos.Repositorio
{

    public class LogRepositorio : ILogRepositorio
    {
        private readonly BancoContext _bancoContext;
        public LogRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;   
            
        }

        public List<LogsModel> BuscarLogs()
        {
            return _bancoContext.Logs.ToList();
        }

        public LogsModel listarPorlogsID(int id)
        {
            return _bancoContext.Logs.FirstOrDefault(a => a.Id == id);
        }

        public LogsModel LogCadastro(LogsModel logsModel)
        {
                _bancoContext.Logs.Add(logsModel);
                _bancoContext.SaveChanges();
                return logsModel; // Retorna o objeto log após a inserção bem-sucedida
        }

        public LogsModel LogDevolucao(LogsModel logsModel)
        {
            _bancoContext.Logs.Add(logsModel);
            _bancoContext.SaveChanges();
            return logsModel; // Retorna o objeto log após a Devolução bem-sucedida
        }

        public LogsModel LogRetirada(LogsModel logsModel)
        {
            _bancoContext.Logs.Add(logsModel);
            _bancoContext.SaveChanges();
            return logsModel; // Retorna o objeto log após a Retirada bem-sucedida
        }
    }
}
