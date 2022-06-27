using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByUserProducerIdAsync(string userProId);
        Task<IEnumerable<Review>> ListByUserArtistIdAsync(string userArtId);
        Task<ReviewResponse> SaveAsync(Review review);
        Task<ReviewResponse> UpdateAsync(int reviewId, Review review);
        Task<ReviewResponse> DeleteAsync(int reviewId);
    }
}