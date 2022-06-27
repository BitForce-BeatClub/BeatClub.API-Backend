using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task<IEnumerable<Publication>> ListByUserIdAsync(string userId);
        Task<PublicationResponse> SaveAsync(Publication publication);
        Task<PublicationResponse> UpdateAsync(int publicationId, Publication publication);
        Task<PublicationResponse> DeleteAsync(int publicationId);
    }
}