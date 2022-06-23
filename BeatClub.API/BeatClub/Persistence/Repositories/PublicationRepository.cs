using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.Shared.Persistence.Contexts;
using BeatClub.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.BeatClub.Persistence.Repositories
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindByIdAsync(int publicationId)
        {
            return await _context.Publications
                    .Include(p=>p.User)
                    .FirstOrDefaultAsync(p=>p.Id==publicationId);
        }

        public async Task<Publication> FindByTitleAsync(string title)
        {
            return await _context.Publications
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Title == title);
        }

        public async Task<IEnumerable<Publication>> FindByUserIdAsync(int userId)
        {
            return await _context.Publications
                .Where(p=>p.UserId==userId)
                .Include(p=>p.User)
                .ToListAsync();
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }
    }
}