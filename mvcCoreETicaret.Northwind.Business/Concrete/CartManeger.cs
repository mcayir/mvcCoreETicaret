using mvcCoreETicaret.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using System.Linq;

namespace mvcCoreETicaret.Northwind.Business.Concrete
{
    public class CartManeger : ICartService
    {
        public void AddtoCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine{Product = product,Quantity=1});
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemovetoCart(Cart cart, int ProductId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c=>c.Product.ProductId==ProductId));
        }
    }
}
