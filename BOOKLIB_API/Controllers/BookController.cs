using BOOKLIB_API.Helpers;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = _bookRepository.Get(x => x.IsAllow == true);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Not Found", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpPost("getall")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = _bookRepository.Get(x => x.IsAllow == true);
            if (result == null)
                return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "Book Not Found", "Please Again Later")));
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
    }
}
