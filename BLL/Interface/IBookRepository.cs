using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IBookRepository
    {
        Book Get(int? id);
        IEnumerable<Book> GetAll();
        int Add(Book book);
        int Update(Book book);
        int Delete(Book book);

    }
}
