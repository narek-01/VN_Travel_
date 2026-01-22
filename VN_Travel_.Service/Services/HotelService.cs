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
    public void CreateHotel(HotelDTO hotelDTO)
    {
        _hotelRepository.CreateHotel(hotelDTO);
    }

    public void DeleteHotel(int id)
    {
        _hotelRepository.DeleteHotel(id);
    }

    public List<HotelModel> GetAll()
    {
        return _hotelRepository.GetAll();
    }

    public HotelModel GetById(int id)
    {
        return _hotelRepository.GetById(id);
    }

    public void UpdateHotel(int id, HotelDTO hotelDTO)
    {
        _hotelRepository.UpdateHotel(id, hotelDTO);
    }
}
