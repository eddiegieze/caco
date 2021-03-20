using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Model;

namespace Caco.API.Services
{
    public interface IBoardService
    {
         Task<IEnumerable<Board>> ListBoardsAsync();
    }
}