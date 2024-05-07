using System.ComponentModel.DataAnnotations;

namespace CategoriasMVC.Models
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O preço é obrigatório")]
        public double Preco { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o ID da categoria.")]
        public int CategoriaId { get; set; }
    }
}
