using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services
{
    public interface ISongListService
    {
        Task<IEnumerable<SongList>> ListAsync();
        Task<IEnumerable<SongList>> ListByUserIdAsync(int userId);
        Task<SongListResponse> SaveAsync(SongList songList);
        Task<SongListResponse> UpdateAsync(int sonListId, SongList songList);
        Task<SongListResponse> DeleteAsync(int sonListId);
    }
}