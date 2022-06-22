using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services.Communication
{
    public class ReviewResponse:BaseResponse<Review>
    {
        public ReviewResponse(Review resource) : base(resource)
        {
        }

        public ReviewResponse(string message) : base(message)
        {
        }
    }
}