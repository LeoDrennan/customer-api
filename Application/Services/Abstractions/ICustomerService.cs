using Domain.Models;

namespace Application.Services.Abstractions;

public interface ICustomerService
{
    Task<List<CustomerModel>> GetAllAsync();
    Task<CustomerModel?> GetByIdAsync(int id);
    Task<CustomerModel> CreateCustomerAsync(CustomerModel customer);
    Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer);
    Task DeleteCustomerById(int id);
}
