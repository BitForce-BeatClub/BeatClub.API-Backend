using BeatClub.API.Learning.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface ICreatorRepository
    {
        Task<IEnumerable<Creator>> ListAsync();
        Task AddAsync(Creator user);
        Task<Creator> FindByIdAsync(int id);
        void Update(Creator user);
        void Remove(Creator user);
    }
}

