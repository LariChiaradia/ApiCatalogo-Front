using CategoriasMVC.Models;
using CategoriasMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAutenticacao _autenticacaoService;

        public AccountController(IAutenticacao autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UsuarioViewModel usuarioVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Login Inválido!");
                return View(usuarioVM);
            }

            var result = await _autenticacaoService.AutenticaUsuario(usuarioVM);

            if(result is null)
            {
                ModelState.AddModelError(string.Empty, "Login Inválido!");
                return View(usuarioVM);
            }

            //Armazenar o token no cookie
            Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
            return Redirect("/");
        }
    }
}
