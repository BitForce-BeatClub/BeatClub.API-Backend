using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
{
    public class CreatorResponse: BaseResponse<Creator>
    {
        public CreatorResponse(Creator resource) : base(resource)
        {
        }

        public CreatorResponse(string message) : base(message)
        {
        }
    }
}

