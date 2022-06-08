using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Repositories;
using BeatClub.API.Learning.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Learning.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _context.Messages
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message> FindByIdAsync(int messageId)
        {
            return await _context.Messages
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == messageId);
        }

        public async Task<Message> FindByContentAsync(string content)
        {
            return await _context.Messages
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Content == content);
        }

        public async Task<IEnumerable<Message>> FindByUserIdAsync(int userId)
        {
            return await _context.Messages
                .Where(p => p.UserId == userId)
                .Include(p=>p.User)
                .ToListAsync();
        }

        public void Update(Message message)
        {
            _context.Messages.Update(message);
        }

        public void Remove(Message message)
        {
            _context.Messages.Remove(message);
        }
    }
}