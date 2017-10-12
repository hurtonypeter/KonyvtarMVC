using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Bll.Models
{
    public class UserEditModel
    {
        public int CardNumber { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Address { get; set; }

        public string MothersName { get; set; }

    }
}
