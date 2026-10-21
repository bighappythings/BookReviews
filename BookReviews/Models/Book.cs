using System.ComponentModel.DataAnnotations;

namespace BookReviews.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public int PublicationDate { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
