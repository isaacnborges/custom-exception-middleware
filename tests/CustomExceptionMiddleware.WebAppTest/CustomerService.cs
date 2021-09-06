using Bogus;
using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Collections.Generic;

namespace CustomExceptionMiddleware.WebAppTest
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> Get(int count)
        {
            return GetCustomers(count);
        }

        public IEnumerable<Customer> GetDomainException()
        {
            throw new InvalidStateException("Custom domain exception message");
        }

        public IEnumerable<Customer> GetCannotAccessException()
        {
            throw new CannotAccessException("Custom cannot access exception message");
        }

        public IEnumerable<Customer> GetNotFoundException()
        {
            throw new NotFoundException("Custom not found exception message");
        }

        public IEnumerable<Customer> GetException()
        {
            #pragma warning disable S112 // General exceptions should never be thrown
            throw new Exception("Custom exception message");
            #pragma warning restore S112 // General exceptions should never be thrown
        }

        private static IEnumerable<Customer> GetCustomers(int count)
        {
            var fake = new Faker<Customer>()
                .CustomInstantiator(x => new Customer
                {
                    Name = x.Person.FullName
                });

            return fake.Generate(count);
        }
    }
}

