using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    //Assignment 2 Start
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        // Example Mon W3 Start
        [Required]
        [StringLength(25)]
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        // Example Mon W3 End
        public string Images { get; set; }
        //Assignment 2 End
    }
}

