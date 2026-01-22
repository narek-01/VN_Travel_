namespace VN_Travel_.DAL.Models;

public class CustomerModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }

    // Documents
    public string PassportId { get; set; }
    public DateTime PassportExpiryDate { get; set; }

    // Contact
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    // Account
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
