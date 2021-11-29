using BOOKLIB_API.Factory;
using BOOKLIB_API.Helpers;
using BOOKLIB_API.Models;
using BOOKLIB_API.Repository;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLIB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IReturnRecordRepository _returnRecordRepository;

        public BookController(IBookRepository bookRepository,IBorrowerRepository borrowerRepository,IReturnRecordRepository returnRecordRepository)
        {
            _bookRepository = bookRepository;
            _borrowerRepository = borrowerRepository;
            _returnRecordRepository = returnRecordRepository;
        }
        [HttpGet("getall")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var borrower = _borrowerRepository.GetAll();
            var returnrec = _returnRecordRepository.GetAll();          
            var difList = borrower.Where(a => !returnrec.Any(a1 => a1.Borrower_ID == a.Id)).Select(x=>x.Bk_ID).ToList();
            var books = _bookRepository.Get(x=> !difList.Any(e=>e.Equals(x.Id)));
            if (books == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Not Found", "Please Again Later")));
            return Ok(new ResponseHelper(1, books, new ErrorDef()));
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
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Update Failed", "Please Again Later")));
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
        [HttpPost("checkout")]
        [Authorize]
        public async Task<IActionResult> Borrower([FromBody] BorrowerModel model)
        {
            var checkout = BorrowerModelFactory.GetBorrowerModel(model);
            var result = _borrowerRepository.Insert(checkout);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Borrower Failed", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpPost("return")]
        [Authorize]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnModel model)
        {
            var returnRecord = ReturnModelFactory.GetReturnModel(model);
            var result = _returnRecordRepository.Insert(returnRecord);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Return Failed", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
    }
}
