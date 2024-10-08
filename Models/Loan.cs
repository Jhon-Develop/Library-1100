using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_1100.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? BookId { get; set; }
        public DateTime LoanSatartDate { get; set; }
        public DateTime LoanEndDate { get; set; }

        public User? User { get; set; }
        public Book? Book { get; set; }
    }
}