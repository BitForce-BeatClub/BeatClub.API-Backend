using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{

    public class TrackRepository : BaseRepository, ITrackRepository
    {
        public TrackRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Track>> ListAsync()
        {
            return await _context.Tracks
                .Include(p => p.Creator)
                .ToListAsync();
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
        }

        public async Task<Track> FindByIdAsync(int trackId)
        {
            return await _context.Tracks
                .Include(p => p.Creator)
                .FirstOrDefaultAsync(p => p.Id == trackId);

        }

        public async Task<Track> FindByContentAsync(string description)
        {
            return await _context.Tracks
                .Include(p => p.Creator)
                .FirstOrDefaultAsync(p => p.Description == description);

        }

        public async Task<IEnumerable<Track>> FindByCreatorIdAsync(int creatorId)
        {
            return await _context.Tracks
                .Where(p => p.CreatorId == creatorId)
                .Include(p=>p.Creator)
                .ToListAsync();
        }

        public void Update(Track track)
        {
            _context.Tracks.Update(track);
        }

        public void Remove(Track track)
        {
            _context.Tracks.Remove(track);
        }
    }
}