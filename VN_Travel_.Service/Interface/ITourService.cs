using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface ITourService
{
    public List<TourModel> GetAll();

    public void CreateTour(TourDTO tourDTO);
    public void UpdateTour(int id, TourDTO tourDTO);
    public void DeleteTour(int id);
    public TourModel GetById(int id);
}
