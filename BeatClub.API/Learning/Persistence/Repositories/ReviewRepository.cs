using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{
    public class ReviewRepository: BaseRepository,IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review> FindByIdAsync(int reviewId)
        {
            return await _context.Reviews
                                .Include(p=>p.UserArtist)
                                .FirstOrDefaultAsync(p=>p.Id==reviewId);
        }

        public async Task<IEnumerable<Review>> FindByUserProducerIdAsync(int userProId)
        {
            return await _context.Reviews.
                    Where(p=>p.UserProducerId==userProId)
                    .Include(p=>p.UserProducer)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Review>> FindByUserArtistIdAsync(int userArtId)
        {
            return await _context.Reviews.
                Where(p=>p.UserArtistId==userArtId)
                .Include(p=>p.UserArtist)
                .ToListAsync();
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public void Remove(Review review)
        {
            _context.Reviews.Update(review);
        }
    }
}