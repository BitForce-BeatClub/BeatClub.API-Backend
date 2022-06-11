using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        Task<Publication> FindByIdAsync(int publicationId);
        Task<Publication> FindByNameAsync(string name);
        Task<IEnumerable<Publication>> FindByUserIdAsync(int userId);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}