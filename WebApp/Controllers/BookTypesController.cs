using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Common.DTOs;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    public class BookTypesController : ApiController
    {
        private readonly IBookService _bookService;
        public BookTypesController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        public async Task<IQueryable<BookTypeDTO>> GetBookTypes()
        {
            return await _bookService.GetAllBookTypes();
        }
    }
}
