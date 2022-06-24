using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> ListAsync();
        Task AddAsync(Membership membership);
        Task<Membership> FindByIdAsync(int membershipId);
        void Update(Membership membership);
        void Remove(Membership membership);
    }
}