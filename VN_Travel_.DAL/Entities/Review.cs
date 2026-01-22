namespace VN_Travel_.DAL.Entities;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsApproved { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int TourId { get; set; }
    public Tour Tour { get; set; }
}
