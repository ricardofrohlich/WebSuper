using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSuper.Pages
{
    public class ProdutoModel : PageModel
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
        public void OnGet()
        {
            Nome = "Café Pilão";
            Preco = 19.90;
            Estoque = 127;
        }
    }
}
