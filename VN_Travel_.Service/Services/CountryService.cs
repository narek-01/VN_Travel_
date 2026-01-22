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
    public void CreateCountry(CountryDTO countryDTO)
    {
        _CountryRepository.CreateCountry(countryDTO);
    }

    public void DeleteCountry(int id)
    {
        _CountryRepository.DeleteCountry(id);
    }

    public List<CountryModel> GetAll()
    {
        return _CountryRepository.GetAll();
    }

    public CountryModel GetById(int id)
    {
        return _CountryRepository.GetById(id);
    }

    public void UpdateCountry(int id, CountryDTO countryDTO)
    {
        _CountryRepository.UpdateCountry(id, countryDTO);
    }
}
