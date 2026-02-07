using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _context;
    public HotelRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task CreateHotelAsync(HotelDTO hotelDTO)
    {
        var hotel = new HotelModel
        {
            Address = hotelDTO.Address,
            BasePricePerNight = hotelDTO.BasePricePerNight,
            CheckInTime = hotelDTO.CheckInTime,
            CheckOutTime = hotelDTO.CheckOutTime,
            City = hotelDTO.City,
            Name = hotelDTO.Name,
            NumberofRooms = hotelDTO.NumberofRooms,
            PhoneNumber = hotelDTO.PhoneNumber,
            RoomTypes = hotelDTO.RoomTypes,
            StarRating = hotelDTO.StarRating,
            WebSite = hotelDTO.WebSite,
        };

        _context.Add(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHotelAsync(int id)
    {
        var hotel = _context.Hotels.Find(id);

        if (hotel == null)
        {
            throw new Exception($"Hotel with ID {id} not found");
        }

        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task<List<HotelModel>> GetAllAsync()
    {
        var hotels = await _context.Hotels.ToListAsync();
        var hotelModels = new List<HotelModel>();

        foreach (var hotel in hotels)
        {
            hotelModels.Add(new HotelModel
            {
                Address = hotel.Address,
                BasePricePerNight = hotel.BasePricePerNight,
                CheckInTime = hotel.CheckInTime,
                CheckOutTime = hotel.CheckOutTime,
                City = hotel.City,
                Name = hotel.Name,
                NumberofRooms = hotel.NumberofRooms,
                PhoneNumber = hotel.PhoneNumber,
                RoomTypes = hotel.RoomTypes,
                StarRating = hotel.StarRating,
                WebSite = hotel.WebSite,
            });
        }

        return hotelModels;
    }

    public async Task<HotelModel> GetByIdAsync(int id)
    {
        var hotels = await _context.Hotels.SingleOrDefaultAsync(x => x.Id == id);
        var hotelModels = new HotelModel
        {
            Address = hotels.Address,
            BasePricePerNight = hotels.BasePricePerNight,
            CheckInTime = hotels.CheckInTime,
            CheckOutTime = hotels.CheckOutTime,
            City = hotels.City,
            Name = hotels.Name,
            NumberofRooms = hotels.NumberofRooms,
            PhoneNumber = hotels.PhoneNumber,
            RoomTypes = hotels.RoomTypes,
            StarRating = hotels.StarRating,
            WebSite = hotels.WebSite,
        };
        return hotelModels;
    }

    public async Task UpdateHotelAsync(int id, HotelDTO hotelDTO)
    {
        var hotel = _context.Hotels.Find(id);

        if (hotel == null)
        {
            throw new Exception($"Hotel with ID {id} not found");
        }
        hotel.WebSite = hotelDTO.WebSite;
        hotel.Name = hotelDTO.Name;
        hotel.NumberofRooms = hotelDTO.NumberofRooms;
        hotel.StarRating = hotelDTO.StarRating;
        hotel.Address = hotelDTO.Address;
        hotel.City = hotelDTO.City;
        hotel.PhoneNumber = hotelDTO.PhoneNumber;
        hotel.RoomTypes = hotelDTO.RoomTypes;
        hotel.CheckInTime = hotelDTO.CheckInTime;
        hotel.CheckOutTime = hotelDTO.CheckOutTime;

        _context.Update(hotel);
        await _context.SaveChangesAsync();
    }
}
