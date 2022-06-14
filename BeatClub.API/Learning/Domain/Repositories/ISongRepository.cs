using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>>  ListAsync();

        Task AddAsync(Song song);

        Task<Song> FindByIdAsync(int songId);
        
        Task<Song> FindByTitleAsync(string title);

        Task<IEnumerable<Song>> FindByUserIdAsync(int userId);
        
        void Update(Song song);
        
        void Remove(Song song);
    }
}