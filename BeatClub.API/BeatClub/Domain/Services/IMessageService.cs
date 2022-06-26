using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListByUserProducerIdAsync(string userProId);
        Task<IEnumerable<Message>> ListByUserArtistIdAsync(string userArtId);
        Task<MessageResponse> SaveAsync(Message message);
        Task<MessageResponse> UpdateAsync(int messageId, Message message);
        Task<MessageResponse> DeleteAsync(int messageId);
    }
}