using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> ListAsync();
        Task<IEnumerable<Song>> ListByUserIdAsync(int userId);
        Task<SongResponse> SaveAsync(Song song);
        Task<SongResponse> UpdateAsync(int songId, Song song);
        Task<SongResponse> DeleteAsync(int songId);
    }
}