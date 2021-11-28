using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class ReturnRecord : HasId
    {
        [ForeignKey(nameof(ReturnRecord_Borrower_Id))]
        public int Borrower_ID { get; set; }
        [ForeignKey(nameof(ReturnRecord_Bk_Id))]
        public int Bk_ID { get; set; }
        [ForeignKey(nameof(ReturnRecord_User_Id))]
        public string User_ID { get; set; }
        public User ReturnRecord_User_Id { get; set; }
        public Book ReturnRecord_Bk_Id { get; set; }
        public Borrower ReturnRecord_Borrower_Id { get; set; }

    }
}
