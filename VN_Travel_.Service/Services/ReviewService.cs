using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    public void CreateReview(ReviewDTO reviewDTO)
    {
        _reviewRepository.CreateReview(reviewDTO);
    }

    public void DeleteReview(int id)
    {
        _reviewRepository.DeleteReview(id);
    }

    public List<ReviewModel> GetAll()
    {
        return _reviewRepository.GetAll();
    }

    public ReviewModel GetById(int id)
    {
        return _reviewRepository.GetById(id);
    }

    public void UpdateReview(int id, ReviewDTO reviewDTO)
    {
        _reviewRepository.UpdateReview(id, reviewDTO);
    }
}
