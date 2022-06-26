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
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _context.Messages
                .Include(p => p.UserTo)
                .Include(p=>p.UserFrom)
                .ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message> FindByIdAsync(int messageId)
        {
            return await _context.Messages
                .Include(p => p.UserTo)
                .Include(p=>p.UserFrom)
                .FirstOrDefaultAsync(p => p.Id == messageId);
        }

        public async Task<Message> FindByContentAsync(string content)
        {
            return await _context.Messages
                .Include(p => p.UserTo)
                .Include(p=>p.UserFrom)
                .FirstOrDefaultAsync(p => p.Content == content);
        }

        public async Task<IEnumerable<Message>> FindByUserIdToAsync(int userIdTo)
        {
            return await _context.Messages.
                Where(p=>p.UserIdTo==userIdTo)
                .Include(p=>p.UserTo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindByUserIdFromAsync(int userIdFrom)
        {
            return await _context.Messages.
                Where(p=>p.UserIdFrom==userIdFrom)
                .Include(p=>p.UserIdFrom)
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