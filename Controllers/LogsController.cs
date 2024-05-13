using ControleContatos.Repositorio;
using ControleDeContatos.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Filters;
using WebApplication1.helper;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]
    public class LogsController : Controller
    {
        private readonly ILogRepositorio _logRepositorio;


        public LogsController(ILogRepositorio logRepositorio)
        {
            _logRepositorio = logRepositorio;
        }

        public IActionResult Index()
        {
            List<LogsModel> logsModels = _logRepositorio.BuscarLogs();
            return View(logsModels);
        }

        public IActionResult viewLogDeRetidada()
        {
            List<LogsModel> logsModels = _logRepositorio.BuscarLogs();
            return PartialView("_viewLogDeRetidada", logsModels);
        }
    }

}