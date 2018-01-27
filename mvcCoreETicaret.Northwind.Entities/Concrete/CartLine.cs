using System.Linq;
using System.Text;

namespace mvcCoreETicaret.Northwind.Entities.Concrete
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
