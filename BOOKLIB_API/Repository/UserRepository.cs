using BOOKLIB_API.Factory;
using BOOKLIB_API.Helpers;
using BOOKLIB_API.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BOOKLIB_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager,SignInManager<User> signInManager,IConfiguration configuration,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddRoleAsync(RoleModel model)
        {
            var result = new IdentityResult();
            var user = await _userManager.FindByIdAsync(model.id);
            if (user == null)
                return result;
            if (model.role=="Admin" && model.accessCode == _configuration["Codes:RoleRequest"])
            {
                result = await _userManager.AddToRoleAsync(user, model.role);
                return result;
            }
            result = await _userManager.AddToRoleAsync(user, model.role);
            return result;
        }

        public async Task<IdentityResult> CreateRoleAsync()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            return new IdentityResult();
        }

        public Task<User> FindByIdAsync(string Id)
        {
            throw new System.NotImplementedException();
        }


        public async Task<IdentityResult> SignUpAsync([FromBody] SignUpModel model)
        {
            var user = UserModelFactory.GetUser(model);
            var userExist = await _userManager.FindByEmailAsync(user.Email);
            var result = new IdentityResult();
            if (userExist == null)
            {
                result =  await _userManager.CreateAsync(user, model.Password);
                await CreateRoleAsync();
                //await _userManager.AddToRoleAsync(user,UserRoles.User);
            }
            return result;
        }
        public async Task<UserModel> SignInAsync(SignInModel model)
        {
            UserModel user = new UserModel();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
                return null;
            var userType = await _userManager.FindByNameAsync(model.Email);
            var Type = await _userManager.GetRolesAsync(userType);
            var claimType = new Claim("role", "User");
            if (Type.Contains("Admin"))
            {
                claimType = new Claim("role", "Admin");
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                claimType
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature));
            user.UserName = userType.Email;
            user.Id = userType.Id;
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            user.UserType = Type;

            return user;
        }
    }
}
