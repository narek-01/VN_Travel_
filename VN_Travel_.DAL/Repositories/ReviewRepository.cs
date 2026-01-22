using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    public ReviewRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public void CreateReview(ReviewDTO reviewDTO)
    {
        var review = new ReviewModel
        {
            Comment = reviewDTO.Comment,
            CreatedAt = DateTime.Now,
            IsApproved = reviewDTO.IsApproved,
            Rating = reviewDTO.Rating,
            Title = reviewDTO.Title,
        };


        _context.Add(review);
        _context.SaveChanges();
    }

    public void DeleteReview(int id)
    {
        var review = _context.Reviews.Find(id);

        if (review == null)
        {
            throw new Exception($"Country with ID {id} not found");
        }

        _context.Reviews.Remove(review);
        _context.SaveChanges();
    }

    public List<ReviewModel> GetAll()
    {
        var reviews = _context.Reviews.ToList();
        var reviewModels = new List<ReviewModel>();

        foreach (var review in reviews)
        {
            reviewModels.Add(new ReviewModel
            {

                Comment = review.Comment,
                CreatedAt = DateTime.Now,
                IsApproved = review.IsApproved,
                Rating = review.Rating,
                Title = review.Title,
            });
        }

        return reviewModels;
    }

    public ReviewModel GetById(int id)
    {
        var review = _context.Reviews.SingleOrDefault(x => x.Id == id);
        var reviewModel = new ReviewModel
        {
            Comment = review.Comment,
            CreatedAt = DateTime.Now,
            IsApproved= review.IsApproved,
            Rating = review.Rating,
            Title = review.Title,
        };
        return reviewModel;
    }

    public void UpdateReview(int id, ReviewDTO reviewDTO)
    {
        var review = _context.Reviews.Find(id);

        if (review == null)
        {
            throw new Exception($"Review with ID {id} not found");
        }
        review.Title = reviewDTO.Title;
        review.Rating = reviewDTO.Rating;
        review.IsApproved = reviewDTO.IsApproved;
        review.Rating = reviewDTO.Rating;
        review.CreatedAt = DateTime.Now;

        _context.Update(review);
        _context.SaveChanges();
    }
}
