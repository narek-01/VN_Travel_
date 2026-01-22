namespace VN_Travel_.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    // Relationships
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }


    // Order details
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }

    // Travel info
    public string Destination { get; set; }
    public DateTime TravelStartDate { get; set; }
    public DateTime TravelEndDate { get; set; }
    public int NumberOfPeople { get; set; }

    // Payment
    public decimal TotalPrice { get; set; }
    public string PaymentStatus { get; set; } // Pending, Paid, Cancelled

    // Order status
    public string Status { get; set; } // New, Confirmed, Completed, Cancelled
    public Tour Tour { get; set; }
    public int TourId { get; set; }
}
