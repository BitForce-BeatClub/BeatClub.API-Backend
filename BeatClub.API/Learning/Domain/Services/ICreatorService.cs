using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services.Communication;


namespace BeatClub.API.Learning.Domain.Services
{
    public interface ICreatorService
    {
        Task<IEnumerable<Creator>> ListAsync();
        Task<CreatorResponse> SaveAsync(Creator user);
        Task<CreatorResponse> UpdateAsync(int id, Creator user);
        Task<CreatorResponse> DeleteAsync(int id);
    }
}

