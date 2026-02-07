using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IReviewRepository
{
    public Task<List<ReviewModel>> GetAllAsync();
    public Task CreateReviewAsync(ReviewDTO reviewDTO);
    public Task UpdateReviewAsync(int id, ReviewDTO reviewDTO);
    public Task DeleteReviewAsync(int id);
    public Task<ReviewModel> GetByIdAsync(int id);
}
