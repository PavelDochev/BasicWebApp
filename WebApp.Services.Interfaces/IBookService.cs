using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.DTOs;

namespace WebApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<IQueryable<BookDTO>> GetAllBooks();
        Task<IQueryable<BookTypeDTO>> GetAllBookTypes();
        Task<BookDTO> GetBook(int bookID);
        Task DeleteBook(int bookID);
        Task<int> AddBook(BookDTO book);
        Task UpdateBook(BookDTO book);
    }
}
