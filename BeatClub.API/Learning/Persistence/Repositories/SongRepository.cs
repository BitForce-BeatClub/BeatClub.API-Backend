using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{
    public class SongRepository: BaseRepository,ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Song>> ListAsync()
        {
            return await _context.Songs
                .Include(p => p.SongList)
                .ToListAsync();
        }

        public async Task AddAsync(Song song)
        {
            await _context.Songs.AddAsync(song);
        }

        public async Task<Song> FindByIdAsync(int songId)
        {
            return await _context.Songs
                .Include(p => p.SongList)
                .FirstOrDefaultAsync(p => p.Id == songId);
        }

        public async Task<Song> FindByNameAsync(string name)
        {
            return await _context.Songs
                .Include(p => p.SongList)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Song>> FindBySongListIdAsync(int songListId)
        {
            return await _context.Songs
                .Where(p => p.SongListId == songListId)
                .Include(p=>p.SongList)
                .ToListAsync();
        }

        public void Update(Song song)
        {
            _context.Songs.Update(song);
        }

        public void Remove(Song song)
        {
            _context.Songs.Update(song);
        }
    }
}