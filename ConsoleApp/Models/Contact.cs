using ConsoleApp.Interfaces;

namespace ConsoleApp.Models;

internal class Contact : IContact
{
    public Guid ContactId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string County { get; set; } = null!;

    public string DisplayName => $"{FirstName} {LastName}";
}
