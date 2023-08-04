using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Dtos
{
    public class ContatoPost
    {
        [Required(ErrorMessage ="Campo nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo e-mail obrigatório!")]
        [EmailAddress(ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Campo de telefone obrigatório!")]
        [Phone(ErrorMessage ="Telefone inválido!")]
        public string Telefone { get; set; }
    }


}
