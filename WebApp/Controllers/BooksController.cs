using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Common.DTOs;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        public async Task<IQueryable<BookDTO>> GetBooks()
        {
            return await _bookService.GetAllBooks();
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDTO book = await _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IHttpActionResult PutBook(int id, BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this._bookService.UpdateBook(book);

            return Ok(id);
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> PostBook(BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int bookId = await this._bookService.AddBook(book);

            return Ok(bookId);
        }

        [HttpDelete]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IHttpActionResult DeleteBook(int id)
        {
            this._bookService.DeleteBook(id);

            return Ok();
        }
    }
}