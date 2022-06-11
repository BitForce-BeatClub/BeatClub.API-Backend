using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{
    public class CreatorRepository : BaseRepository, ICreatorRepository
    {
        public CreatorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Creator>> ListAsync()
        {
            return await _context.Creators.ToListAsync();
        }

        public async Task AddAsync(Creator creator)
        {
            await _context.Creators.AddAsync(creator);
        }

        public async Task<Creator> FindByIdAsync(int id)
        {
            return await _context.Creators.FindAsync(id);
        }

        public void Update(Creator creator)
        {
            _context.Creators.Update(creator);
        }

        public void Remove(Creator creator)
        {
            _context.Creators.Remove(creator);
        }
    }
}

