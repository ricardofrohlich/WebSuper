using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSuper.Pages
{
    public class ProdutoModel : PageModel
    {
        public List<Produto> Produtos { get; set; } 

        public void OnGet()
        {

            Produtos = new List<Produto>
            {
                new Produto {Nome = "Café Pilão", Preco = 19.90, Estoque = 127},
                new Produto {Nome = "Café Melitta", Preco = 24.90, Estoque = 33},
                new Produto {Nome = "Coca cola zero", Preco = 9.90, Estoque = 570},
                new Produto {Nome = "Erva Mate Rei Verde", Preco = 12.70, Estoque = 27},
                new Produto {Nome = "Queijo Mussarela", Preco = 49.90, Estoque = 133}
            };            
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
    }
}
