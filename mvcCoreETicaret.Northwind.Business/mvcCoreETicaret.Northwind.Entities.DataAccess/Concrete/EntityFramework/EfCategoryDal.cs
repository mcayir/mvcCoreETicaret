using mvcCoreETicaret.Core.DataAccess.EntityFramework;
using mvcCoreETicaret.Northwind.DataAccess.Abstract;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvcCoreETicaret.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}
