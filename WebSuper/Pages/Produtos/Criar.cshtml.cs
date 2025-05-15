using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace ExemploAula.Pages.Produtos
{
    public class CriarModel : PageModel
    {
        [BindProperty] //vincula os dados do formulario html �s propriedades do modelo da p�gina 
        //quando eu envio um formulario pelo m�todo POST
        public Produto p { get; set; }
        public void OnGet()
        {
            //Console.WriteLine("estou aqui");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                using (var writer = new StreamWriter("produtos.txt", true))
                {
                    writer.WriteLine(p.Id + ";" + p.Descricao + ";" + p.Preco);
                }
                return RedirectToPage("/Produtos/Index");
            }
        }
    }
}
