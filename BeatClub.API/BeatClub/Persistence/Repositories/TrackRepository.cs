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
    public class TrackRepository: BaseRepository,ITrackRepository
    {
        public TrackRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Track>> ListAsync()
        {
            return await _context.Tracks
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
        }

        public async Task<Track> FindByIdAsync(int trackId)
        {
            return await _context.Tracks
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == trackId);
        }

        public async Task<Track> FindByTitleAsync(string title)
        {
            return await _context.Tracks
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Title == title);
        }

        public async Task<IEnumerable<Track>> FindByUserIdAsync(int userId)
        {
            return await _context.Tracks
                .Where(p => p.UserId == userId)
                .Include(p=>p.User)
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