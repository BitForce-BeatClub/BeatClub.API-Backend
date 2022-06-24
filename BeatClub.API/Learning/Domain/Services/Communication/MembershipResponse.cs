using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
{
    public class MembershipResponse : BaseResponse<Membership>
    {
        public MembershipResponse(Membership resource) : base(resource)
        {
        }

        public MembershipResponse(string message) : base(message)
        {
        }
    }
}