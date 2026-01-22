using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface IReviewService
{
    public List<ReviewModel> GetAll();

    public void CreateReview(ReviewDTO reviewDTO);
    public void UpdateReview(int id, ReviewDTO reviewDTO);
    public void DeleteReview(int id);
    public ReviewModel GetById(int id);
}
