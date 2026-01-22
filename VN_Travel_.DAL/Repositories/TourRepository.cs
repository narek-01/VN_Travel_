using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class TourRepository : ITourRepository
{
    private readonly ApplicationDbContext _context;
    public TourRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public void CreateTour(TourDTO tourDTO)
    {
        var tour = new TourModel
        {
            Country = tourDTO.Country,
            Description = tourDTO.Description,
            Destinations = tourDTO.Destinations,
            DurationDays = tourDTO.DurationDays,
            EndDate = tourDTO.EndDate,
            MaxParticipants = tourDTO.MaxParticipants,
            Name = tourDTO.Name,
            PricePerPerson = tourDTO.PricePerPerson,
            StartDate = tourDTO.StartDate,
            Transfer = tourDTO.Transfer,
        };

        _context.Add(tour);
        _context.SaveChanges();
    }

    public void DeleteTour(int id)
    {
        var tour = _context.Tours.Find(id);

        if (tour == null)
        {
            throw new Exception($"Tour with ID {id} not found");
        }

        _context.Tours.Remove(tour);
        _context.SaveChanges();
    }

    public List<TourModel> GetAll()
    {
        var tours = _context.Tours.ToList();
        var tourModels = new List<TourModel>();

        foreach (var tour in tours)
        {
            tourModels.Add(new TourModel
            {
                Country = tour.Country,
                Description = tour.Description,
                Destinations = tour.Destinations,
                DurationDays = tour.DurationDays,
                EndDate = tour.EndDate,
                MaxParticipants = tour.MaxParticipants,
                Name = tour.Name,
                PricePerPerson = tour.PricePerPerson,
                StartDate = tour.StartDate,
                Transfer = tour.Transfer,
            });
        }

        return tourModels;
    }

    public TourModel GetById(int id)
    {
        var tour = _context.Tours.SingleOrDefault(x => x.Id == id);
        var tourModel = new TourModel
        {
            Country = tour.Country,
            Description = tour.Description,
            Destinations = tour.Destinations,
            DurationDays = tour.DurationDays,
            EndDate = tour.EndDate,
            MaxParticipants = tour.MaxParticipants,
            Name = tour.Name,
            PricePerPerson = tour.PricePerPerson,
            StartDate = tour.StartDate,
            Transfer = tour.Transfer,
        };
        return tourModel;
    }

    public void UpdateTour(int id, TourDTO tourDTO)
    {
        var tour = _context.Tours.Find(id);

        if (tour == null)
        {
            throw new Exception($"Country with ID {id} not found");
        }
        tour.Country = tour.Country;
        tour.Description = tour.Description;
        tour.Destinations = tour.Destinations;
        tour.DurationDays = tour.DurationDays;
        tour.EndDate = tour.EndDate;
        tour.MaxParticipants = tour.MaxParticipants;
        tour.Name = tour.Name;
        tour.PricePerPerson = tour.PricePerPerson;
        tour.StartDate = tour.StartDate;
        tour.Transfer = tour.Transfer;

        _context.Update(tour);
        _context.SaveChanges();
    }
}
