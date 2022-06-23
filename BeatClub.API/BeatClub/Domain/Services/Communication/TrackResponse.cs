using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services.Communication
{
    public class TrackResponse:BaseResponse<Track>
    {
        public TrackResponse(Track resource) : base(resource)
        {
        }

        public TrackResponse(string message) : base(message)
        {
        }
    }
}