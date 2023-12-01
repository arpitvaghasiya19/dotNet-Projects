using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAjax.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PinCode { get; set; }


        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        
    }

}
