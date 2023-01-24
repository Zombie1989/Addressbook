namespace ConsoleApp.Interfaces;

internal interface IContact
{
    Guid ContactId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Address { get; set; }
    public string PostalCode { get; set; }
    public string County { get; set; }

}
