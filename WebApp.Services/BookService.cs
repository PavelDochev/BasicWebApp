using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.DTOs;
using WebApp.Data;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class BookService : IBookService
    {
        private readonly WebAppDBEntities dbContext;
        public BookService(WebAppDBEntities context)
        {
            dbContext = context;
        }

        public async Task<int> AddBook(BookDTO book)
        {
            //booktype should be taken by bookTypeID
            var bookType = dbContext.BookTypes.FirstOrDefault(x => x.Name == book.BookType);

            if (bookType == null) throw new NullReferenceException();

            Book entity = new Book
            {
                BookID = book.BookID,
                Author = book.Author,
                Title = book.Title,
                BookTypeID = bookType.BookTypeID,
                Description = book.Description,
                PublishedOn = book.PublishedOn
            };

            dbContext.Books.Add(entity);
            dbContext.SaveChanges();

            return entity.BookID;
        }

        public async Task DeleteBook(int bookID)
        {
            Book book = dbContext.Books.FirstOrDefault(x => x.BookID == bookID);
            if (book == null) throw new NullReferenceException();

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public async Task<IQueryable<BookDTO>> GetAllBooks()
        {
            var res = dbContext.Books.Include(x => x.BookType).Select(x => new BookDTO
            {
                Title = x.Title,
                BookID = x.BookID,
                Author = x.Author,
                BookType = x.BookType.Name,
                PublishedOn = x.PublishedOn,
                Description = x.Description
            });

            return res;
        }

        public async Task<IQueryable<BookTypeDTO>> GetAllBookTypes()
        {
            var res = dbContext.BookTypes.Select(x => new BookTypeDTO
            {
                BookTypeID = x.BookTypeID,
                Name = x.Name
            });
            return res;
        }

        public async Task<BookDTO> GetBook(int bookID)
        {
            var res = await dbContext.Books.Select(x => new BookDTO
            {
                Title = x.Title,
                BookID = x.BookID,
                Author = x.Author,
                BookType = x.BookType.Name,
                PublishedOn = x.PublishedOn,
                Description = x.Description
            }).FirstOrDefaultAsync(x => x.BookID == bookID);
            return res;
        }

        public async Task UpdateBook(BookDTO book)
        {
            if (book == null) throw new Exception("err");

            //get booktype by id instead of name
            var bookType = dbContext.BookTypes.FirstOrDefault(x => x.Name == book.BookType);
            Book entity = new Book
            {
                BookID = book.BookID,
                Author = book.Author,
                Title = book.Title,
                BookTypeID = bookType.BookTypeID,
                Description = book.Description,
                PublishedOn = book.PublishedOn,
            };

            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();

        }
    }
}
