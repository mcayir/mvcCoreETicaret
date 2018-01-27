using System;
using System.Collections.Generic;
using System.Linq;

namespace mvcCoreETicaret.Northwind.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }
        public Decimal Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}
