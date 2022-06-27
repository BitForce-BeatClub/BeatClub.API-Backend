using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        Task<Publication> FindByIdAsync(int publicationId);
        Task<Publication> FindByTitleAsync(string title);
        Task<IEnumerable<Publication>> FindByUserIdAsync(int userId);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}