using System.Threading.Tasks;
using BeatClub.API.Shared.Domain.Repositories;
using BeatClub.API.Shared.Persistence.Contexts;

namespace BeatClub.API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}