﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonyvtarMVC.Web.Models.Member
{
    public class MemberDetailsViewModel
    {
        public int CardNumber { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Address { get; set; }

        public string MothersName { get; set; }

        public List<MemberRentListViewModel> Rents { get; set; } = new List<MemberRentListViewModel>();
    }
}
