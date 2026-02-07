using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;
    public CountryRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task CreateCountryAsync(CountryDTO countryDTO)
    {
        var country = new CountryModel
        {
            CapitalCity = countryDTO.CapitalCity,
            Currency = countryDTO.Currency,
            Description = countryDTO.Description,
            Name = countryDTO.Name,
            Region_Continent = countryDTO.Region_Continent,
            TimeZone = countryDTO.TimeZone,
        };

        _context.Add(country);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCountryAsync(int id)
    {
        var country = _context.Countries.Find(id);

        if (country == null)
        {
            throw new KeyNotFoundException($"Country with ID {id} not found");
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CountryModel>> GetAllAsync()
    {
        var countries = await _context.Countries.ToListAsync();
        var countryModels = new List<CountryModel>();

        foreach (var country in countries)
        {
            countryModels.Add(new CountryModel
            {
                CapitalCity = country.CapitalCity,
                Currency = country.Currency,
                Description = country.Description,
                Name = country.Name,
                Region_Continent = country.Region_Continent,
                TimeZone = country.TimeZone,
            });
        }

        return countryModels;
    }

    public async Task<CountryModel> GetByIdAsync(int id)
    {
        var country = await _context.Countries.SingleOrDefaultAsync(x => x.Id == id);
        var countryModel = new CountryModel
        {
            Name = country.Name,
            CapitalCity = country.CapitalCity,
            Currency = country.Currency,
            Description = country.Description,
            Region_Continent = country.Region_Continent,
            TimeZone = country.TimeZone,
        };
        return countryModel;
    }

    public async Task UpdateCountryAsync(int id, CountryDTO countryDTO)
    {
        var country = _context.Countries.Find(id);

        if (country == null)
        {
            throw new KeyNotFoundException($"Country with ID {id} not found");
        }

        country.Name = countryDTO.Name;
        country.CapitalCity = countryDTO.CapitalCity;
        country.Currency = countryDTO.Currency;
        country.Description = countryDTO.Description;
        country.Region_Continent = countryDTO.Region_Continent;
        country.TimeZone = countryDTO.TimeZone;

        _context.Update(country);
        await _context.SaveChangesAsync();
    }

}
