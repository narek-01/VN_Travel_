using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface ICountryRepository
{
    public Task<List<CountryModel>> GetAllAsync();
    public Task CreateCountryAsync(CountryDTO countryDTO);
    public Task UpdateCountryAsync(int id, CountryDTO countryDTO);
    public Task DeleteCountryAsync(int id);
    public Task<CountryModel> GetByIdAsync(int id);
}
