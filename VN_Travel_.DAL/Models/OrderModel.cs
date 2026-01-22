namespace VN_Travel_.DAL.Models;

public class OrderModel
{
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
    public string Status { get; set; }
}
