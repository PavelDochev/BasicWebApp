using System;

namespace WebApp.Common.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public int BookID { get; set; }
        public string Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Description { get; set; }
        public string BookType { get; set; }
    }
}
