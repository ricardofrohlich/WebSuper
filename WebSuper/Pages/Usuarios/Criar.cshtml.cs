using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace WebSuper.Pages.Usuarios
{
    public class CriarModel : PageModel
    {
        [BindProperty] //vincula os dados do formulario HTML � propriedade do modelo
        public Usuario usuario { get; set; } //Objeto vai ser armazenado no arquivo
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) // verifica��o se o modelo/informa�oes inseridas no formul�rio satisfazem a necessidade definida na classe
            {
                using(var writer = new StreamWriter("usuarios.txt", true)) //abrindo o arquivo para escrita
                {
                    writer.WriteLine(usuario.Id+";"+usuario.Nome+";"+usuario.Senha+";"+usuario.Email); //escrevendo no arquivo
                    return RedirectToPage("Index"); //redireciona para a p�gina de listagem de usu�rios

                }
            }
            // Se o modelo n�o for v�lido, retornar � mesma p�gina com os erros
            return Page();
        }
    }
}
