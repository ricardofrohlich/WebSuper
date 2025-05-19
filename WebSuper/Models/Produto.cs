using System.ComponentModel.DataAnnotations;

namespace WebSuper.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(30, ErrorMessage="A descrição deve ter até 30 caracteres")]
        public string Descricao { get; set; }
        public double Preco { get; set; }

    }
}
