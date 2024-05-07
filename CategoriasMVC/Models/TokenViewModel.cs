namespace CategoriasMVC.Models
{
    public class TokenViewModel
    {
        public bool Authenticate { get; set; }
        public DateTime Expiration { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
    }
}
