using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_1100.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }

        public DocumentType? DocumentType { get; set; }
        public Role? Role { get; set; }
        public required ICollection<Loan> Loans { get; set; }

    }
}