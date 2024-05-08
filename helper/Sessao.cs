using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContex;

        public Sessao(IHttpContextAccessor httpContex)
        {
            _httpContex = httpContex;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContex.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContex.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaUsuario()
        {
            _httpContex.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
