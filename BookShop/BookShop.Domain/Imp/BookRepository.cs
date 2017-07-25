using BookShop.Domain.Core;
using BookShop.Domain.Entities;
using BookShop.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Imp
{
    public class BookRepository : IBookRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Book> Books
        {
            get { return context.Books; }
        }

        private static List<Book> GetBooks()
        {
            //为了演示，这里手工造一些数据，后面会介绍使用EF从数据库中读取。
            List<Book> books = new List<Book>{
            new Book { ID = 1, Title = "ASP.NET MVC 4 编程", Price = 52},
            new Book { ID = 2, Title = "CLR Via C#", Price = 46},
            new Book { ID = 3, Title = "平凡的世界", Price = 37}
        };
            return books;
        }
    }
}
