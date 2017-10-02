using KonyvtarMVC.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Dal.Entities
{
    public class BookItem
    {
        public string Id { get; set; }

        public string Barcode { get; set; }

        public BookCondition Condition { get; set; }

        //TODO: ez egy notmapped property, ami a Rents-ből megmondja, hogy kölcsönzött/szabad/lejárt-e az állapota
        public string State { get; set; }

        public string BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}
