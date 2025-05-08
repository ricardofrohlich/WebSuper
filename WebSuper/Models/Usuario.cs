namespace WebSuper.Models
{
    public class Usuario
    {
        public int Id { get; set; } //Identificador do usuario -> único, para gente já ir se acostumando...
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
