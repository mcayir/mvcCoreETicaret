using System;
using System.Collections.Generic;
using System.Text;
using mvcCoreETicaret.Core.Entities;

namespace mvcCoreETicaret.Northwind.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
