using mvcCoreETicaret.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace mvcCoreETicaret.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
       
    }
}
