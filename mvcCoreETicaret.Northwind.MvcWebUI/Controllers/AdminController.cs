﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcCoreETicaret.Northwind.Business.Abstract;
using mvcCoreETicaret.Northwind.MvcWebUI.Models;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
       public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {   
              _productService.Add(product);
              TempData.Add("message", "Ürün Eklendi.");
            }
            
            return RedirectToAction("Add");
        }
        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürün Güncellendi");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "Ürün Silindi");
            return RedirectToAction("Index");
        }
    }
}