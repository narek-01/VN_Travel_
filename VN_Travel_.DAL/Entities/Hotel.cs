namespace VN_Travel_.DAL.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public int StarRating { get; set; }
    public int NumberofRooms { get; set; }
    public string RoomTypes { get; set; }
    public TimeOnly CheckInTime { get; set; }
    public TimeOnly CheckOutTime { get; set; }
    public decimal BasePricePerNight { get; set; }
    public string WebSite { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public List<Tour> Tours { get; set; }





}
