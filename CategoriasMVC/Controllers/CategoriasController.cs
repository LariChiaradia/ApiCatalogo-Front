using CategoriasMVC.Models;
using CategoriasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaViewModel>>> Index()
        {
            var result = await _categoriaService.GetCategorias();

            if (result is null)
                return View("Error");

            return View(result);
        }
    }
}
