using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace WebSuper.Pages.Usuarios
{
    public class CriarModel : PageModel
    {
        [BindProperty] //vincula os dados do formulario HTML à propriedade do modelo
        public Usuario usuario { get; set; } //Objeto vai ser armazenado no arquivo
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) // verificação se o modelo/informaçoes inseridas no formulário satisfazem a necessidade definida na classe
            {
                using(var writer = new StreamWriter("usuarios.txt", true)) //abrindo o arquivo para escrita
                {
                    writer.WriteLine(usuario.Id+";"+usuario.Nome+";"+usuario.Senha+";"+usuario.Email); //escrevendo no arquivo
                    return RedirectToPage("Index"); //redireciona para a página de listagem de usuários

                }
            }
            // Se o modelo não for válido, retornar à mesma página com os erros
            return Page();
        }
    }
}
