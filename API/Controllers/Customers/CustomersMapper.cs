using Domain.Models;
using API.Controllers.Customers.Contracts;

namespace API.Controllers.Customers
{
    public static class CustomersMapper
    {
        public static CustomersListResponse Map(List<CustomerModel> customers)
        {
            return new CustomersListResponse
            {
                Customers = customers.Select(x => new CustomerResponse
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                })
            };
        }

        public static CustomerResponse Map(CustomerModel customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

        }

        public static CustomerModel Map(CustomerRequest request)
        {
            return new CustomerModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
        }

        public static CustomerModel Map(int id, CustomerRequest request)
        {
            return new CustomerModel
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}
