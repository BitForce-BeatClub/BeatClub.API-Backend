using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task AddAsync(Message message);
        Task<Message> FindByIdAsync(int messageId);
        Task<Message> FindByContentAsync(string content);
        Task<IEnumerable<Message>> FindByUserIdAsync(int userId);
        void Update(Message message);
        void Remove(Message message);
    }
}