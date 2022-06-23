using System.Threading.Tasks;

namespace BeatClub.API.BeatClub.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        
    }
}