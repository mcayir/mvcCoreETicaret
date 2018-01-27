using mvcCoreETicaret.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvcCoreETicaret.Northwind.Business.Abstract
{
    public interface ICartService
    {
        void AddtoCart(Cart cart, Product product);
        void RemovetoCart(Cart cart, int ProductId);
        List<CartLine> List(Cart cart);
    }
}
