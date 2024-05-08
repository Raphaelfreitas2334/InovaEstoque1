using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]

    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
