using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> ListBoardsAsync();
        Task<BoardResponse> SaveAsync(Board board);
        Task<BoardResponse> UpdateAsync(int id, Board board);
        Task<BoardResponse> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}