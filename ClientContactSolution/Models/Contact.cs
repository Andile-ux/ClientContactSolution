using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientContactSolution.Models
{
    public class Contact
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public virtual ICollection<ClientContact> ClientContacts { get; set; }
    }
}