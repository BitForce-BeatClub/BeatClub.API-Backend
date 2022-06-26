using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.Shared.Persistence.Contexts;
using BeatClub.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.BeatClub.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository,IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<Payment> FindByIdAsync(int paymentId)
        {
            return await _context.Payments
                .Include(p=>p.User)
                .FirstOrDefaultAsync(p=>p.Id==paymentId);
        }

        public async Task<IEnumerable<Payment>> FindByUserIdAsync(string userId)
        {
            return await _context.Payments
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
        }

        public void Remove(Payment payment)
        {
            _context.Payments.Remove(payment);
        }
    }
}