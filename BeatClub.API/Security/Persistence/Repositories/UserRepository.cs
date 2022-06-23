using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Domain.Repositories;
using BeatClub.API.Shared.Persistence.Contexts;
using BeatClub.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Security.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindNicknameAsync(string nickname)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Nickname == nickname);
        }

        public bool ExistByNickname(string nickname)
        {
            return _context.Users.Any(x => x.Nickname == nickname);
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}