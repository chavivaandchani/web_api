using Entity;

namespace Repository
{
    public interface IRatingRepository
    {
        Task<Rating> addRequest(Rating RatingDetails);
    }
}