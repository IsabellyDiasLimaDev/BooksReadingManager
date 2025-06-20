using BookReadingManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingManager.Application.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public long PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }  
        public BookFormat Format { get; set; }
        public ReadingStatus Status { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
