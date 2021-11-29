using BOOKLIB_API.DataContext;
using DataAccessLayer;

namespace BOOKLIB_API.Repository
{
    public class BorrowerRepository : RepositoryBase<Borrower>, IBorrowerRepository
    {
        public BorrowerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
