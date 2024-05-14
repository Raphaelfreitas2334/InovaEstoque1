using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class FiltroCozinheiro : ViewComponent
    {
        private readonly IAlimentoRepositorio _alimentoRepositorio;

        public FiltroCozinheiro(IAlimentoRepositorio alimentoRepositorio)
        {
            _alimentoRepositorio = alimentoRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return View(alimentos);
        }
    }
}
