using System;

namespace BOOKLIB_API.Models
{
    public class BorrowerModel
    {
        public int Bk_ID { get; set; }
        public string User_ID { get; set; }
        public int Bk_Copies { get; set; }
        public DateTime? Release_Date { get; set; } = DateTime.Now;
        public DateTime? Due_Date { get; set; } = DateTime.Now.AddDays(1);
    }
}
