using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public interface IBoardService
    {
         public Task<IEnumerable<Board>> ListBoardsAsync();
         Task<SaveBoardResponse> SaveAsync(Board board);
         Task<SaveBoardResponse> UpdateAsync(int id, Board board);
    }
}