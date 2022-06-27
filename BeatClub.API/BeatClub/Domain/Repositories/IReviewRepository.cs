using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task AddAsync(Review review);
        Task<Review> FindByIdAsync(int reviewId);
        Task<IEnumerable<Review>> FindByUserProducerIdAsync(int userProId);
        Task<IEnumerable<Review>> FindByUserArtistIdAsync(int userArtId);
        void Update(Review review);
        void Remove(Review review);
    }
}