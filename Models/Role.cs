using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_1100.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public required ICollection<User> Users { get; set; } 
    }
}