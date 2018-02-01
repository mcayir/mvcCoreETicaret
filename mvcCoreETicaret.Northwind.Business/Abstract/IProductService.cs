using mvcCoreETicaret.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace mvcCoreETicaret.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
