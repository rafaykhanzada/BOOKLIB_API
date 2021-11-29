using BOOKLIB_API.Models;
using DataAccessLayer;

namespace BOOKLIB_API.Factory
{
    public class ReturnModelFactory
    {
        public static ReturnRecord GetReturnModel(ReturnModel model)
        {
            var returnRecord = new ReturnRecord();
            if (model != null)
            {
               returnRecord.User_ID = model.User_ID;
               returnRecord.CreatedOn = System.DateTime.Now;
               returnRecord.UpdatedOn = System.DateTime.Now;
               returnRecord.IsAllow = true;
               returnRecord.Bk_ID = model.Bk_ID;
               returnRecord.Borrower_ID = model.Borrower_ID;   
            }
            return returnRecord;
        }
    }
}
