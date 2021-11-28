using BOOKLIB_API.DataContext;
using DataAccessLayer;

namespace BOOKLIB_API.Repository
{
    public class BookRepository: RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
