using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class HotelService : IHotelService
{
    private readonly IOrderRepository _hotelRepository;

    public HotelService(IOrderRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    public void CreateCountry(HotelDTO hotelDTO)
    {
        throw new NotImplementedException();
    }

    public void DeleteCountry(int id)
    {
        throw new NotImplementedException();
    }

    public List<HotelModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public HotelModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateCountry()
    {
        throw new NotImplementedException();
    }
}
