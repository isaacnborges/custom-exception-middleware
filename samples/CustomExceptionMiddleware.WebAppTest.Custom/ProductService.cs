using Bogus;
using System.Collections.Generic;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> Get(int productsCount)
        {
            return GetProducts(productsCount);
        }

        public IEnumerable<Product> GetDomainException(bool returnProducts)
        {
            if (returnProducts)
                return GetProducts();

            throw new CustomDomainException("Custom domain exception message");
        }

        private static IEnumerable<Product> GetProducts(int customersCount = 10)
        {
            var fake = new Faker<Product>()
                .CustomInstantiator(x => new Product
                {
                    Description = x.Commerce.Product()
                });

            return fake.Generate(customersCount);
        }
    }
}
