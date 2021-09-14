using System.Collections.Generic;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    public interface IProductService
    {
        IEnumerable<Product> Get(int productsCount);
        IEnumerable<Product> GetDomainException(bool returnProducts);
    }
}