namespace VN_Travel_.DAL.DTOs;

public class ReviewDTO
{
    public int Rating { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsApproved { get; set; }

}
