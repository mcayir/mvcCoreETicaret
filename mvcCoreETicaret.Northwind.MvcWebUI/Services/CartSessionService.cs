using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using mvcCoreETicaret.Northwind.MvcWebUI.ExtensionMethods;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService (IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
       
        public Cart GetCart()
        {
            Cart carttoCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (carttoCheck==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                carttoCheck= _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return carttoCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
