using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<IEnumerable<Payment>> ListByUserIdAsync(string userId);
        Task<PaymentResponse> SaveAsync(Payment payment);
        Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment);
        Task<PaymentResponse> DeleteAsync(int paymentId);
    }
}