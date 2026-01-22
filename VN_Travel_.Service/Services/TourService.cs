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
    public void CreateTour(TourDTO tourDTO)
    {
        _tourRepository.CreateTour(tourDTO);
    }

    public void DeleteTour(int id)
    {
        _tourRepository.DeleteTour(id);
    }

    public List<TourModel> GetAll()
    {
        return _tourRepository.GetAll();
    }

    public TourModel GetById(int id)
    {
        return _tourRepository.GetById(id);
    }

    public void UpdateTour(int id, TourDTO tourDTO)
    {
        _tourRepository.UpdateTour(id, tourDTO);
    }
}
