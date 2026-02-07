using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface IHotelService
{
    public Task<List<HotelModel>> GetAllAsync();
    public Task CreateHotelAsync(HotelDTO hotelDTO);
    public Task UpdateHotelAsync(int id, HotelDTO hotelDTO);
    public Task DeleteHotelAsync(int id);
    public Task<HotelModel> GetByIdAsync(int id);
}
