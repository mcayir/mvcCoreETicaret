using mvcCoreETicaret.Core.DataAccess;
using mvcCoreETicaret.Northwind.Entities.Concrete;

namespace mvcCoreETicaret.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //View ilgili yaomak istediğimiz şeyleri yazacğımız yer.
    }
}
