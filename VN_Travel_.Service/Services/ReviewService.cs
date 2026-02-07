using System.Threading.Tasks;
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
    public async Task CreateReviewAsync(ReviewDTO reviewDTO)
    {
       await _reviewRepository.CreateReviewAsync(reviewDTO);
    }

    public async Task DeleteReviewAsync(int id)
    {
        await _reviewRepository.DeleteReviewAsync(id);
    }

    public async Task<List<ReviewModel>> GetAllAsync()
    {
        return await _reviewRepository.GetAllAsync();
    }

    public async Task<ReviewModel> GetByIdAsync(int id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task UpdateReviewAsync(int id, ReviewDTO reviewDTO)
    {
        await _reviewRepository.UpdateReviewAsync(id, reviewDTO);
    }
}
