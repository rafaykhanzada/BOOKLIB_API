using BOOKLIB_API.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BOOKLIB_API.Repository
{
    public interface IUserRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<UserModel> SignInAsync(SignInModel model);
        public Task<IdentityResult> CreateRoleAsync();
        public Task<IdentityResult> AddRoleAsync(RoleModel model);
        public Task<User> FindByIdAsync(String Id);
        public void SignOut();
    }
}
