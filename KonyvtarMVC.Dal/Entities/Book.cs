using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Dal.Entities
{
    public class Book
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }
        
        public virtual ICollection<BookItem> BookItems { get; set; }
    }
}
