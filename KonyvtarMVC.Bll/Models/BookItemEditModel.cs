using KonyvtarMVC.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Bll.Models
{
    public class BookItemEditModel
    {
        public string Barcode { get; set; }

        public BookCondition Condition { get; set; }
    }
}
