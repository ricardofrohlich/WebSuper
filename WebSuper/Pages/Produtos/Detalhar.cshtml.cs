using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace WebSuper.Pages.Produtos
{
    public class DetalharModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }
        public IActionResult OnGet(int id)
        {
            //Carregando a lista de produtos do arquivo TXT
            var produtos = CarregarProdutos();

            //Usar o método da classe LIST FirstOrDefault para encontrar o produto usando o ID e o LIN -> expressão lambda

            Produto = produtos.FirstOrDefault(p => p.Id == id);

            if (Produto == null)
            {
                return RedirectToPage("/Produtos/Index");
            }
            else
            {
                return Page();
            }
        }


        public List<Produto> CarregarProdutos()
        {
            var produtos = new List<Produto>();

            if (System.IO.File.Exists("produtos.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("produtos.txt");
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    var produto = new Produto()
                    {
                        Id = int.Parse(dados[0]),
                        Descricao = dados[1],
                        Preco = double.Parse(dados[2])
                    };
                    produtos.Add(produto);
                }
            }
            return produtos;
        }
    }
}
