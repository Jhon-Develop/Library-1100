using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_1100.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public int CategoryId { get; set; }
        public bool? Avalibility { get; set; }

        public Category? Category { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}