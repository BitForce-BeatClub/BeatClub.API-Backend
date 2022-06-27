using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.BeatClub.Domain.Services.Communication;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Domain.Services.Communication;

namespace BeatClub.API.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(int id, UpdateRequest request);
        Task DeleteAsync(int id);
    }
}