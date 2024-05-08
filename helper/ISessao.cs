using WebApplication1.Models;

namespace WebApplication1.helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
