using System.Threading.Tasks;

namespace BeatClub.API.Learning.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        
    }
}