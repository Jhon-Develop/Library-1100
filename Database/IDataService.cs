using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_1100.Models;

namespace library_1100.Database
{
    public interface IDataService
    {
        Task<List<User>> GetUsers();
        Task<List<DocumentType>> GetDocumentTypes();
        Task<List<Role>> GetRoles();
        Task<List<Loan>> GetLoans();
        Task<List<Book>> GetBooks();
        Task<List<Category>> GetCategories();
    }
}