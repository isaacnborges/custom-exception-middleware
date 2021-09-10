using System.Collections.Generic;

namespace CustomExceptionMiddleware.WebAppTest
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get(int customersCount);
        IEnumerable<Customer> GetDomainException();
        IEnumerable<Customer> GetCannotAccessException();
        IEnumerable<Customer> GetNotFoundException();
        IEnumerable<Customer> GetException();
    }
}

