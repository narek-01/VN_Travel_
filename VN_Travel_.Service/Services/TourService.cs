using System.Threading.Tasks;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class TourService : ITourService
{
    private readonly ITourRepository _tourRepository;
    public TourService(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }
    public async Task CreateTourAsync(TourDTO tourDTO)
    {
        await _tourRepository.CreateTourAsync(tourDTO);
    }

    public async Task DeleteTourAsync(int id)
    {
       await _tourRepository.DeleteTourAsync(id);
    }

    public async Task<List<TourModel>> GetAllAsync()
    {
        return await _tourRepository.GetAllAsync();
    }

    public async Task<TourModel> GetByIdAsync(int id)
    {
        return await _tourRepository.GetByIdAsync(id);
    }

    public async Task UpdateTourAsync(int id, TourDTO tourDTO)
    {
        await _tourRepository.UpdateTourAsync(id, tourDTO);
    }
}
