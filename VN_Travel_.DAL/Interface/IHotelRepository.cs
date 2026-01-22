using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IHotelRepository
{
    public List<HotelModel> GetAll();
    public void CreateHotel(HotelDTO hotelDTO);
    public void UpdateHotel(int id, HotelDTO hotelDTO);
    public void DeleteHotel(int id);
    public HotelModel GetById(int id);
}
