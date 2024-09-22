using Infrastructure.Data.Entities.Abstractions;

namespace Infrastructure.Data.Entities;

public class Customer : EntityBase
{
    private Customer()
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
