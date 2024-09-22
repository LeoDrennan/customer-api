namespace API.Controllers.Customers.Contracts
{
    public class CustomersListResponse
    {
        public IEnumerable<CustomerResponse> Customers { get; set; } = [];
    }
}
