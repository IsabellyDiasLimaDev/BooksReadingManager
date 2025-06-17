using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string publisher { get; set; } = string.Empty;
        public long pageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        [Precision(10,2)]
        public decimal Price { get; set; } = 0.0m;

    }
}
