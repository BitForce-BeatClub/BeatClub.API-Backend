using BeatClub.API.Learning.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> ListAsync();
        Task AddAsync(Track track);
        Task<Track> FindByIdAsync(int trackId);
        Task<Track> FindByContentAsync(string description);
        Task<IEnumerable<Track>> FindByCreatorIdAsync(int creatorId);
        void Update(Track track);
        void Remove(Track track);
    }
}

