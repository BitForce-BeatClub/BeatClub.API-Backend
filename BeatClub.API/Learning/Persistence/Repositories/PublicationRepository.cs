using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
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

        public async Task<Publication> FindByNameAsync(string name)
        {
            return await _context.Publications
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Name == name);
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