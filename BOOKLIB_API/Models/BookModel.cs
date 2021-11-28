using System;

namespace BOOKLIB_API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public int Bk_Number { get; set; }
        public DateTime? Publish_Date { get; set; }
    }
}
