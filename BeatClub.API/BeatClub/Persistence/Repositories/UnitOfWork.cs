using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Persistence.Contexts;

namespace BeatClub.API.BeatClub.Persistence.Repositories
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