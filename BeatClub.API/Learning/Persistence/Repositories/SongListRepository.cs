using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{
    public class SongListRepository : BaseRepository, ISongListRepository
    {
        public SongListRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SongList>> ListAsync()
        {
            return await _context.SongLists
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(SongList songList)
        {
            await _context.SongLists.AddAsync(songList);
        }

        public async Task<SongList> FindByIdAsync(int songListId)
        {
            return await _context.SongLists
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == songListId);
        }

        public async Task<SongList> FindByNameAsync(string name)
        {
            return await _context.SongLists
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<SongList>> FindByUserIdAsync(int userId)
        {
            return await _context.SongLists
                .Where(p => p.UserId == userId)
                .Include(p=>p.User)
                .ToListAsync();
        }

        public void Update(SongList songList)
        {
            _context.SongLists.Update(songList);
        }

        public void Remove(SongList songList)
        {
            _context.SongLists.Remove(songList);
        }
    }
}