using Bogus;
using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Collections.Generic;

namespace CustomExceptionMiddleware.WebAppTest
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> Get(int customersCount)
        {
            return GetCustomers(customersCount);
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
            throw new Exception("Custom exception message");
        }

        private static IEnumerable<Customer> GetCustomers(int customersCount)
        {
            var fake = new Faker<Customer>()
                .CustomInstantiator(x => new Customer
                {
                    Name = x.Person.FullName
                });

            return fake.Generate(customersCount);
        }
    }
}