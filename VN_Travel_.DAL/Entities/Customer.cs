namespace VN_Travel_.DAL.Entities;

public class Customer
{
    // Personal info
    public int Id { get; set; }
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
    public List<Order> Orders { get; set; }
    public List<Review> Reviews { get; set; }
}
