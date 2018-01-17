using mvcCoreETicaret.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using mvcCoreETicaret.Northwind.DataAccess.Abstract;

namespace mvcCoreETicaret.Northwind.Business.Concrete
{
    public class CategoryManeger : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManeger(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
