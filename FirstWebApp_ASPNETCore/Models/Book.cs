using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_ASPNETCore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int BorrowedId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Customer Borrower { get; set; }
    }
}
