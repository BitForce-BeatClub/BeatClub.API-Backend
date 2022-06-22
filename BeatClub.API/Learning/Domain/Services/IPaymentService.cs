using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<IEnumerable<Payment>> ListByUserIdAsync(int userId);
        Task<PaymentResponse> SaveAsync(Payment payment);
        Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment);
        Task<PaymentResponse> DeleteAsync(int paymentId);
    }
}