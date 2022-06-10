using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface ISongListRepository
    {
        Task<IEnumerable<SongList>>  ListAsync();

        Task AddAsync(SongList songList);

        Task<SongList> FindByIdAsync(int songListId);
        
        Task<SongList> FindByNameAsync(string name);

        Task<IEnumerable<SongList>> FindByUserIdAsync(int userId);
        
        void Update(SongList songList);
        
        void Remove(SongList songList);

    }
}