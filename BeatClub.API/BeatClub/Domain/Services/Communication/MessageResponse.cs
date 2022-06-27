using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services.Communication
{
    public class MessageResponse: BaseResponse<Message>
    {
        public MessageResponse(Message resource) : base(resource)
        {
        }

        public MessageResponse(string message) : base(message)
        {
        }
    }
}