using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
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