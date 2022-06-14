using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;

namespace BeatClub.API.Learning.Domain.Services
{
    public interface IMembershipService
    {
        Task<IEnumerable<Membership>> ListAsync();
        Task<MembershipResponse> SaveAsync(Membership membership);
        Task<MembershipResponse> UpdateAsync(int id, Membership membership);
        Task<MembershipResponse> DeleteAsync(int id);
    }
}