using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSuper.Models;

namespace WebSuper.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        public List<Usuario> Usuarios { get; set; } //Lista de usuarios que foi cadastrada no arquiv
        public void OnGet()
        {
            Usuarios = new List<Usuario>();
            //aqui, vou percorrer o arquivo e vou adicionando elementos à lista
            if (System.IO.File.Exists("usuarios.txt"))
            {
                //vou ler todas as linhas do arquivo em uma variavel
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");
                //agora, vou percorrer as linhas e adicionar os elementos à lista
                foreach (var linha in linhas) 
                { 
                    var dados = linha.Split(';'); //dividindo a linha em cada separador ;
                    //dados[0] -> receber o ID
                    //dados[1] -> receber o Nome
                    //dados[2] -> receber a Senha
                    //dados[3] -> receber o Email
                    Usuario usuario = new Usuario();
                    usuario.Id = int.Parse(dados[0]); //converte o dado para inteiro
                    usuario.Nome = dados[1]; 
                    usuario.Senha = dados[2];
                    usuario.Email = dados[3];
                    Usuarios.Add(usuario); //adicionando o usuario à lista
                }
            }
        }
    }
}
