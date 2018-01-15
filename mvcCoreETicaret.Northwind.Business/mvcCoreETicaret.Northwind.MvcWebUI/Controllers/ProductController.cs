using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcCoreETicaret.Northwind.Business.Abstract;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using mvcCoreETicaret.Northwind.MvcWebUI.Models;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

     
        public ActionResult Index()
        {

            var products = _productService.GetAll();
            ProductListViewModel model=new ProductListViewModel
            {
                Products = products
            };
            return View();
        }
    }
}