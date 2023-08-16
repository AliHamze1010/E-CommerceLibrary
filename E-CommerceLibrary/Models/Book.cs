using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace E_CommerceLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string author { get; set; }

        public int ISBN { get; set; }

        public string genre { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}