using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_ASPNETCore.Data
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Authors.Include(x => x.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Authors.Where(x => x.AuthorId == id).Include(x => x.Books).FirstOrDefault();
        }
    }
}
