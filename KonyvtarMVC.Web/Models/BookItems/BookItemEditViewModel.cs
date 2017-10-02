using KonyvtarMVC.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonyvtarMVC.Web.Models.BookItems
{
    public class BookItemEditViewModel
    {
        public int? Id { get; set; }

        public string Barcode { get; set; }

        public BookCondition Condition { get; set; }
    }
}
