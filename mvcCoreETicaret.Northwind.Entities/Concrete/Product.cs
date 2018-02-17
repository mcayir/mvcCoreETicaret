using System;
using System.Collections.Generic;
using System.Text;
using mvcCoreETicaret.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace mvcCoreETicaret.Northwind.Entities.Concrete
{
    public class Product:IEntity
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public short UnitsInStock { get; set; }
    }
}
