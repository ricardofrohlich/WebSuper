using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace ExemploAula.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        public List<Produto> Produtos { get; set; }
        public void OnGet()
        {
            Produtos = new List<Produto>();
            if(System.IO.File.Exists("produtos.txt"))
            {
                using (var reader = new StreamReader("produtos.txt"))
                {
                    var linhas = System.IO.File.ReadAllLines("produtos.txt");
                    foreach (var linha in linhas)
                    {
                        string[] campos = linha.Split(';');
                        var p = new Produto();
                        p.Id = int.Parse(campos[0]);
                        p.Descricao = campos[1];
                        p.Preco = double.Parse(campos[2]);
                        Produtos.Add(p);
                    }
                }
            }
        }
    }
}
