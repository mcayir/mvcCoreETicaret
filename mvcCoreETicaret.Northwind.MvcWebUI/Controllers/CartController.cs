using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcCoreETicaret.Northwind.MvcWebUI.Services;
using mvcCoreETicaret.Northwind.Business.Abstract;
using mvcCoreETicaret.Northwind.MvcWebUI.Models;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddtoCart(cart,productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message",String.Format("->,{0},Ürününüz Sepete Eklendi.",productToBeAdded.ProductName));
            return RedirectToAction("Index","Product");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
    }
}