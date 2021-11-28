using BOOKLIB_API.Helpers;
using BOOKLIB_API.Models;
using BOOKLIB_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BOOKLIB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
        {
            var result = await _userRepository.SignInAsync(model);
            if (result == null)
                return Unauthorized();
            return Ok(new ResponseHelper(1, result, new ErrorDef()));
        }
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpModel model)
        {
            var result = await _userRepository.SignUpAsync(model);
            if (result.Succeeded)
                return Ok(new ResponseHelper(1, result, new ErrorDef()));
            return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "User not create", "Please using another email")));
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleModel model)
        {
           var result = await _userRepository.AddRoleAsync(model);
            if (result.Succeeded)
                return Ok(new ResponseHelper(1, result, new ErrorDef()));
            return Ok(new ResponseHelper(0, new object(), new ErrorDef((int)EnumHelper.ErrorEnums.NoRecordFound, "User role not create", "Please use valid code")));

        }
    }
}
