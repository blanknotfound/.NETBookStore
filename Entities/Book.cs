using System.ComponentModel.DataAnnotations;

namespace learning.Entities;
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [Required]
        [StringLength(300)]
        public required string Description { get; set; }

        [Required]
        [StringLength(40)]
        public required string Genre { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Author { get; set; }

        [Url]
        [StringLength(200)]
        public  required string imageUrl { get; set; }

        public DateTime ReleaseDate{ get; set; }

        [Range(1,300)]
        public decimal Price{ get; set; }
    }