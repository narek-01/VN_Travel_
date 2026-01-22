namespace VN_Travel_.DAL.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CapitalCity { get; set; }
    public string Region_Continent { get; set; }
    public string Currency { get; set; }
    public string TimeZone { get; set; }
    public List<Hotel> Hotel { get; set; } 



}
