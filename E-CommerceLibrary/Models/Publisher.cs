using System.ComponentModel.DataAnnotations;

namespace E_CommerceLibrary.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required(ErrorMessage = "Publisher Name is required.")]
        [StringLength(150, ErrorMessage = "Publisher Name cannot exceed 150 characters.")]
        public string PublisherName { get; set; }
    }
}
