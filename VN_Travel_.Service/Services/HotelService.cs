using System.Threading.Tasks;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    public async Task CreateHotelAsync(HotelDTO hotelDTO)
    {
        await _hotelRepository.CreateHotelAsync(hotelDTO);
    }

    public async Task DeleteHotelAsync(int id)
    {
        await _hotelRepository.DeleteHotelAsync(id);
    }

    public async Task<List<HotelModel>> GetAllAsync()
    {
        return await _hotelRepository.GetAllAsync();
    }

    public async Task<HotelModel> GetByIdAsync(int id)
    {
        return await _hotelRepository.GetByIdAsync(id);
    }

    public async Task UpdateHotelAsync(int id, HotelDTO hotelDTO)
    {
        await _hotelRepository.UpdateHotelAsync(id, hotelDTO);
    }
}
