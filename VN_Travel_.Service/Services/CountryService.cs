using System.Threading.Tasks;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _CountryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _CountryRepository = countryRepository;
    }
    public async Task CreateCountryAsync(CountryDTO countryDTO)
    {
        await _CountryRepository.CreateCountryAsync(countryDTO);
    }

    public async Task DeleteCountry(int id)
    {
        await _CountryRepository.DeleteCountryAsync(id);
    }

    public async Task<List<CountryModel>> GetAllAsync()
    {
        return await _CountryRepository.GetAllAsync();
    }

    public async Task<CountryModel> GetByIdAsync(int id)
    {
        return await _CountryRepository.GetByIdAsync(id);
    }

    public async Task UpdateCountryAsync(int id, CountryDTO countryDTO)
    {
       await _CountryRepository.UpdateCountryAsync(id, countryDTO);
    }
}
