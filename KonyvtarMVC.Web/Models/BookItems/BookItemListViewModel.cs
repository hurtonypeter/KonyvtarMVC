using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonyvtarMVC.Web.Models.BookItems
{
    public class BookItemListViewModel
    {
        public string Id { get; set; }

        public string Barcode { get; set; }

        public string Status { get; set; }
    }
}
