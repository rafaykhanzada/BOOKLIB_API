using BOOKLIB_API.Models;
using DataAccessLayer;

namespace BOOKLIB_API.Factory
{
    public class BorrowerModelFactory
    {
        public static Borrower GetBorrowerModel(BorrowerModel model)
        {
            var borrower = new Borrower();
            if (model != null)
            {
                borrower.User_ID = model.User_ID;
                borrower.UpdatedOn = System.DateTime.Now;
                borrower.Release_Date = model.Release_Date.Value;
                borrower.CreatedOn = System.DateTime.Now;
                borrower.Due_Date = model.Due_Date.Value;
                borrower.IsAllow = true;
                borrower.Bk_Copies = model.Bk_Copies;
                borrower.Bk_ID = model.Bk_ID;
    }
            return borrower;
        }
    }
}
