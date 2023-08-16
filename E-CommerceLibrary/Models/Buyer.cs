using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceLibrary.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerID { get; set; }

        [Required(ErrorMessage = "Buyer Name is required.")]
        [StringLength(100, ErrorMessage = "Buyer Name cannot be longer than 100 characters.")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Book is required.")]
        [ForeignKey("Book")]
        public int BookID { get; set; }

        public virtual Book Book { get; set; }
    }
}
