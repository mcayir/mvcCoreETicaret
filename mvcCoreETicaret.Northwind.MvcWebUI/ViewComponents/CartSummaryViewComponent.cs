using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcCoreETicaret.Northwind.MvcWebUI.Services;
using mvcCoreETicaret.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace mvcCoreETicaret.Northwind.MvcWebUI.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private ICartSessionService _cartSessionSerivice;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionSerivice = cartSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionSerivice.GetCart()
            };
        return View(model);
        }
    }
}
