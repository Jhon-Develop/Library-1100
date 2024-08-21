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
        public string? Address { get; set; }
        public string? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RoleId { get; set; }

        public DocumentType? DocumentType { get; set; }
        public Role? Role { get; set; }
        public required ICollection<Loan> Loans { get; set; }

    }
}