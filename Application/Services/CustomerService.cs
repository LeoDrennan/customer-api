using Domain.Models;
using Application.Services.Abstractions;
using Infrastructure.Data.Repositories.Abstractions;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<CustomerModel>> GetAllAsync()
            => await _customerRepository.GetAllAsync();

        public async Task<CustomerModel?> GetByIdAsync(int id)
            => await _customerRepository.GetByIdAsync(id);

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer)
            => await _customerRepository.AddAsync(customer);

        public async Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer)
            => await _customerRepository.UpdateAsync(customer);

        public async void DeleteCustomerById(int id)
            => await _customerRepository.DeleteByIdAsync(id);
    }
}
