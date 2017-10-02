using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Dal.Entities
{
    public class Rent
    {
        public string Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string BookItemId { get; set; }

        public virtual BookItem BookItem { get; set; }
    }
}
