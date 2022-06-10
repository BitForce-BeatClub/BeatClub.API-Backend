using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
{
    public class SongListResponse : BaseResponse<SongList>
    {
        public SongListResponse(SongList resource) : base(resource)
        {
        }

        public SongListResponse(string message) : base(message)
        {
        }
    }
}