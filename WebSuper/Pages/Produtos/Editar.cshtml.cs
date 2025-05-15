using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace WebSuper.Pages.Produtos
{
    public class EditarModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }
        public void OnGet(int id)
        {
            var produtos = CarregarProdutos();
            Produto = produtos.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var linhas = System.IO.File.ReadAllLines("produtos.txt").ToList();

            for(int i = 0; i < linhas.Count; i++)
            {
                var dados = linhas[i].Split(';');
                if (int.Parse(dados[0]) == Produto.Id)
                {
                    linhas[i] = Produto.Id + ";" + Produto.Descricao + ";" + Produto.Preco;
                    break;
                }
            }
            System.IO.File.WriteAllLines("produtos.txt", linhas);
            return RedirectToPage("/Produtos/Index");

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
