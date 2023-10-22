using BLL.Interface;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context) 
        {
            _context = context;
        }


        public int Add(Book book)
        {
            _context.Books.Add(book);
            return _context.SaveChanges();

        }

        public int Delete(Book book)
        {
            _context.Books.Remove(book);
            return _context.SaveChanges();
        }

        public Book Get(int? id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }



        public IEnumerable<Book> GetAll()
            => _context.Books.ToList();

        public int Update(Book book)
        {
            _context.Books.Update(book);
            return _context.SaveChanges();
        }
    }
}
