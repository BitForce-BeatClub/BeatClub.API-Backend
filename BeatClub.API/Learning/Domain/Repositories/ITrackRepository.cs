using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>>  ListAsync();

        Task AddAsync(Track track);

        Task<Track> FindByIdAsync(int trackId);
        
        Task<Track> FindByTitleAsync(string title);

        Task<IEnumerable<Track>> FindByUserIdAsync(int userId);
        
        void Update(Track track);
        
        void Remove(Track track);
    }
}