using CategoriasMVC.Models;

namespace CategoriasMVC.Services.Interfaces
{
    public interface IAutenticacao
    {
        Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM);
    }
}
