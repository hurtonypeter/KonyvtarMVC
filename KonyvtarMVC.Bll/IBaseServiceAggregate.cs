using KonyvtarMVC.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Bll
{
    public interface IBaseServiceAggregate
    {
        BookStoreContext Context { get; }
    }
}
