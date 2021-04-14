
using System.Threading.Tasks;

namespace Caco.API.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}