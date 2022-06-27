using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Shared.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services.Communication
{
    public class PaymentResponse: BaseResponse<Payment>
    {
        public PaymentResponse(Payment resource) : base(resource)
        {
        }

        public PaymentResponse(string message) : base(message)
        {
        }
    }
}