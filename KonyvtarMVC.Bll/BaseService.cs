using KonyvtarMVC.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Bll
{
    public abstract class BaseService
    {
        protected readonly BookStoreContext context;

        public BaseService(IBaseServiceAggregate aggregate)
        {
            context = aggregate.Context;
        }
    }
}
