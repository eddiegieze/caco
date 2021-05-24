
using System.Threading.Tasks;

namespace Caco.API.Repositories
{
    public interface IChangeSet
    {
         Task CompleteAsync();
    }
}