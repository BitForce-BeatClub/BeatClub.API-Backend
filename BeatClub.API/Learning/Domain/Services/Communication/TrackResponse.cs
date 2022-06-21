using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
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