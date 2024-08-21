using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_1100.Models;

namespace library_1100.Database
{
    public class DataService : IDataService
    {
        public Task<List<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentType>> GetDocumentTypes()
        {
            throw new NotImplementedException();
        }

        public Task<List<Loan>> GetLoans()
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}