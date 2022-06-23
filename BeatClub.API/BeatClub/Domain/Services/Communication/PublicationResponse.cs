using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services.Communication
{
    public class PublicationResponse:BaseResponse<Publication>
    {
        public PublicationResponse(Publication resource) : base(resource)
        {
        }

        public PublicationResponse(string message) : base(message)
        {
        }
    }
}