using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Bll.Exceptions
{
    public class BllException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
    }
}
