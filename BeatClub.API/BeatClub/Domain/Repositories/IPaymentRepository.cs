using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task AddAsync(Payment payment);
        Task<Payment> FindByIdAsync(int paymentId);
        Task<IEnumerable<Payment>> FindByUserIdAsync(int userId);
        void Update(Payment payment);
        void Remove(Payment payment);
    }
}