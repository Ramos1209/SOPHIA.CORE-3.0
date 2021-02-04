using System.Threading.Tasks;

namespace SOPHIA_Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
