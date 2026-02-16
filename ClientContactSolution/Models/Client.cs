using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientContactSolution.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ClientCode { get; set; }

        public virtual ICollection<ClientContact> ClientContacts { get; set; }
    }
}