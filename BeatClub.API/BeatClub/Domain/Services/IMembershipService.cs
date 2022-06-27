using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services.Communication;

namespace BeatClub.API.BeatClub.Domain.Services
{
    public interface IMembershipService
    {
        Task<IEnumerable<Membership>> ListAsync();
        Task<MembershipResponse> SaveAsync(Membership membership);
        Task<MembershipResponse> UpdateAsync(int id, Membership membership);
        Task<MembershipResponse> DeleteAsync(int id);
    }
}