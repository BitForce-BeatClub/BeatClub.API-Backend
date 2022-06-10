using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
{
    public class SongResponse:BaseResponse<Song>
    {
        public SongResponse(Song resource) : base(resource)
        {
        }

        public SongResponse(string message) : base(message)
        {
        }
    }
}