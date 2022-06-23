using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<Track>> ListAsync();
        Task<IEnumerable<Track>> ListByUserIdAsync(int userId);
        Task<TrackResponse> SaveAsync(Track track);
        Task<TrackResponse> UpdateAsync(int trackId, Track track);
        Task<TrackResponse> DeleteAsync(int trackId);
    }
}