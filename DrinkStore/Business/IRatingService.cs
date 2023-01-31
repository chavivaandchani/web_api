using Entity;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> addRequest(Rating rating);
    }
}