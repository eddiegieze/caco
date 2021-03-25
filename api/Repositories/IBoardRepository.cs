using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;

namespace Caco.API.Repositories
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> ListAsync();
        Task AddAsync(Board board);
        Task<Board> FindByIdAsync(int id);
        void Update(Board board);
    }
}