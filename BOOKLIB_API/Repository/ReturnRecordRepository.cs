using BOOKLIB_API.DataContext;
using DataAccessLayer;

namespace BOOKLIB_API.Repository
{
    public class ReturnRecordRepository: RepositoryBase<ReturnRecord>, IReturnRecordRepository
    {
        public ReturnRecordRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
