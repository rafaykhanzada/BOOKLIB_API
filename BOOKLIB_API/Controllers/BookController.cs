using BOOKLIB_API.Factory;
using BOOKLIB_API.Helpers;
using BOOKLIB_API.Models;
using BOOKLIB_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BOOKLIB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("getall")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = _bookRepository.Get(x => x.IsAllow == true);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Not Found", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpGet("get/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = _bookRepository.Get(x => x.IsAllow == true && x.Id==id);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Not Found", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook([FromBody] BookModel model)
        {
            var book = BookModelFactory.GetBookModel(model);
            var result = _bookRepository.Insert(book);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Add Failed", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel model1)
        {
            var book = BookModelFactory.GetBookModel(model1);
            var result = _bookRepository.Update(book);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Add Failed", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpGet("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = _bookRepository.GetById(id);      
            if (book != null)
                _bookRepository.Delete(book);
            return Ok(new ResponseHelper(1, book, new ErrorDef()));
        }
    }
}
