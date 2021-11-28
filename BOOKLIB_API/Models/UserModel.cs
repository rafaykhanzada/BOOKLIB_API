using System.Collections.Generic;

namespace BOOKLIB_API.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IList<string> UserType { get; set; }
        public string Token { get; set; }
    }
}
