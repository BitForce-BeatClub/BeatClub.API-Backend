using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task AddAsync(Message message);
        Task<Message> FindByIdAsync(int messageId);
        Task<Message> FindByContentAsync(string content);
        Task<IEnumerable<Message>> FindByUserIdFromAsync(int userIdFrom);
        Task<IEnumerable<Message>> FindByUserIdToAsync(int userIdTo);
        void Update(Message message);
        void Remove(Message message);
    }
}