using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services
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