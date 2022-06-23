using System.Collections.Generic;
using System.Threading.Tasks;
using BeatClub.API.Security.Domain.Models;

namespace BeatClub.API.Security.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindNicknameAsync(string nickname);
        bool ExistByNickname(string nickname);
        User FindById(int id);
        void Update(User user);
        void Remove(User user);
    }
}