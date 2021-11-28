namespace BOOKLIB_API.Helpers
{
    public static class EnumHelper
    {
        public enum ErrorEnums
        {
            EmptyData = 1,
            NoRecordFound = 2,
            DataAlreadyExist = 3,
            InvalidData = 4,
            Exception = 5
        }
    }
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
