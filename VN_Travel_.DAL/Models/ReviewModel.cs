namespace VN_Travel_.DAL.Models;

public class ReviewModel
{
    public int Rating { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsApproved { get; set; }
}
