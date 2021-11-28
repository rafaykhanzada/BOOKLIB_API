using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
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
        public DateTime? Publish_Date { get; set; }
    }
}
