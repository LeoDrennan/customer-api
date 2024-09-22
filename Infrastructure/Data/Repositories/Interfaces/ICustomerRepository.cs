using Domain.Models;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories.Abstractions;

public interface ICustomerRepository : IGenericRepository<Customer, CustomerModel>
{
}