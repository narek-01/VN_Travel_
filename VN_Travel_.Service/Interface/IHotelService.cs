using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface IHotelService
{
    public List<CountryModel> GetAll();

    public void CreateCountry(CountryDTO countryDTO);
    public void UpdateCountry();
    public void DeleteCountry(int id);
    public CountryModel GetById(int id);
}
