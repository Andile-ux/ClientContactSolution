using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientContactSolution.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<ClientContact> ClientContacts { get; set; }
    }
}