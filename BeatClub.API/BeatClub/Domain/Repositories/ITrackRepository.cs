using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>>  ListAsync();

        Task AddAsync(Track track);

        Task<Track> FindByIdAsync(int trackId);
        
        Task<Track> FindByTitleAsync(string title);

        Task<IEnumerable<Track>> FindByUserIdAsync(string userId);
        
        void Update(Track track);
        
        void Remove(Track track);
    }
}