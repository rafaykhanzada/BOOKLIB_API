using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Borrower : HasId
    {
        [ForeignKey(nameof(Borrower_Bk_Id))]
        public int Bk_ID { get; set; }
        [ForeignKey(nameof(Borrower_User_Id))]
        public string User_ID { get; set; }
        public int Bk_Copies { get; set; }
        public DateTime Release_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public Book Borrower_Bk_Id { get; set; }
        public User Borrower_User_Id { get; set; }

        public ICollection<ReturnRecord> ReturnRecord_Borrower_Id { get; set; }
    }
}
