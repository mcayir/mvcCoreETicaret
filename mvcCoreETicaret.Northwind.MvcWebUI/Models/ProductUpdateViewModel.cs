using System.Collections.Generic;
using mvcCoreETicaret.Northwind.Entities.Concrete;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}