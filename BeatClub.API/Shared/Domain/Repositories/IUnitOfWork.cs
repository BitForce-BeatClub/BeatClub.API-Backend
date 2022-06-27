using System.Threading.Tasks;

namespace BeatClub.API.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        
    }
}