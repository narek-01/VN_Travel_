using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface ITourService
{
    public Task<List<TourModel>> GetAllAsync();
    public Task CreateTourAsync(TourDTO tourDTO);
    public Task UpdateTourAsync(int id, TourDTO tourDTO);
    public Task DeleteTourAsync(int id);
    public Task<TourModel> GetByIdAsync(int id);
}
}
