using AutoMapper;
using Domain.Models;
using Infrastructure.Data.Abstractions;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstractions;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories;

internal sealed class CustomerRepository : GenericRepository<Customer, CustomerModel>, ICustomerRepository
{
    public CustomerRepository(CustomerDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
