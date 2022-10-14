using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishingHouse { get; set; }
        public int PageCount { get; set; }
        public bool IsInLibrary { get; set; }
        public static int maxVal = 0;
        public Book(int id, string title, string publisher, int pageC,bool isInLibr) 
        {
            Id = id;
            Title = title;
            PublishingHouse = publisher;
            PageCount = pageC;
            IsInLibrary = isInLibr;
            maxVal = Math.Max(maxVal, id);
        }
        
    }
}
