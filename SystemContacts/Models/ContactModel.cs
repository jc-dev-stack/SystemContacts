using System.ComponentModel.DataAnnotations;

namespace SystemContacts.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Digite o email do contato")]
        [EmailAddress(ErrorMessage ="Email invalido!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o telefone do contato")]
        [Phone(ErrorMessage ="Telefone invalido!")]
        public string Phone { get; set; }
    }
}
    