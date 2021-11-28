using BOOKLIB_API.Models;
using DataAccessLayer;

namespace BOOKLIB_API.Factory
{
    public class BookModelFactory
    {
        public static Book GetBookModel(BookModel model)
        {
          var book = new Book();
            if (model!=null)
            {
                book.Id = model.Id;
                book.Title = model.Title;
                book.Publisher = model.Publisher;
                book.Author = model.Author;
                book.Publish_Date = model.Publish_Date;
                book.BookName = model.BookName;
                book.Bk_Number = model.Bk_Number;
                book.IsAllow = true;
                book.Author = model.Author;
                book.CreatedOn = System.DateTime.Now;
                book.UpdatedOn = System.DateTime.Now;
            }
            return book;
        }
    }
}
