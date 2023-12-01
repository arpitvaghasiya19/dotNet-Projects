using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CodeFirstAjax.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(5, 110)]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        public Address Address { get; set; }
    }

}
