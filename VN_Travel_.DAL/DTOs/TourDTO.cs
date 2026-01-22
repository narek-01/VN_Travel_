namespace VN_Travel_.DAL.DTOs;

public class TourDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public decimal PricePerPerson { get; set; }
    public int DurationDays { get; set; }
    public string Destinations { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxParticipants { get; set; }
    public string Transfer { get; set; }
}
