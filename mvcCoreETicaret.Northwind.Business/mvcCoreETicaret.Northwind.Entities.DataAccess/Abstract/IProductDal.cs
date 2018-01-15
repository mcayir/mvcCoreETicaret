using mvcCoreETicaret.Core.DataAccess;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvcCoreETicaret.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //View ilgili yaomak istediğimiz şeyleri yazacğımız yer.
    }
}
