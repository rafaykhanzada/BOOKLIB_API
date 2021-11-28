using BOOKLIB_API.Models;
using DataAccessLayer;

namespace BOOKLIB_API.Factory
{
    public class UserModelFactory
    {
        public static User GetUser(SignUpModel model)
        {
            User user = new User();
            if (model != null)
            {
                user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Country = model.Country,
                    Email = model.Email,
                    UserName = model.Email
                };
            }
           
            return user;
        }
    }
}
