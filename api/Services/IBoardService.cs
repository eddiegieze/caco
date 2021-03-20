using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;

namespace Caco.API.Services
{
    public interface IBoardService
    {
         public Task<IEnumerable<Board>> ListBoardsAsync();
    }
}