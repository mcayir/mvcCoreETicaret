using mvcCoreETicaret.Core.DataAccess;
using mvcCoreETicaret.Northwind.Entities.Concrete;

namespace mvcCoreETicaret.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Product>
    {
        //View ilgili yaomak istediğimiz şeyleri yazacğımız yer.
    }
}
