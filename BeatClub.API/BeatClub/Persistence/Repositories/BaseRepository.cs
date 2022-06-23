using BeatClub.API.BeatClub.Persistence.Contexts;

namespace BeatClub.API.BeatClub.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}