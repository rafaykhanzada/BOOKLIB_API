using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Book :HasId
    {
        public string Title { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public int Bk_Number { get; set; }
        public int Bk_Copies { get; set; }
        public string Bk_Edition { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Bk_Cost { get; set; }
        public DateTime? Publish_Date { get; set; }
        public ICollection<Borrower> Borrower_Bk_Id { get; set; }
        public ICollection<ReturnRecord> ReturnRecord_Bk_Id { get; set; }
    }
}
