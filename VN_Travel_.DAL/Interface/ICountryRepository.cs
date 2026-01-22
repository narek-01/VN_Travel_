using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface ICountryRepository
{
    public List<CountryModel> GetAll();
    public void CreateCountry(CountryDTO countryDTO);
    public void UpdateCountry(int id, CountryDTO countryDTO);
    public void DeleteCountry(int id);
    public CountryModel GetById(int id);
}
