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
                .Include(p => p.UserFrom)
                .Include(p=>p.UserTo)
                .ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message> FindByIdAsync(int messageId)
        {
            return await _context.Messages
                .Include(p => p.UserFrom)
                .Include(p=>p.userIdTo)
                .FirstOrDefaultAsync(p => p.id == messageId);
        }

        public async Task<Message> FindByContentAsync(string content)
        {
            return await _context.Messages
                .Include(p => p.UserFrom)
                .Include(p=>p.UserTo)
                .FirstOrDefaultAsync(p => p.content == content);
        }

        public async Task<IEnumerable<Message>> FindByUserIdFromAsync(string userIdFrom)
        {
            return await _context.Messages.
                Where(p=>p.userIdFrom==userIdFrom)
                .Include(p=>p.UserFrom)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindByUserIdToAsync(string userIdTo)
        {
            return await _context.Messages.
                Where(p=>p.userIdTo==userIdTo)
                .Include(p=>p.UserTo)
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