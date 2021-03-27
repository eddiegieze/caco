using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;

namespace Caco.API.Repositories
{
    public interface IColumnRepository
    {
        Task<IEnumerable<Column>> ListAsync(int boardId);
        Task AddAsync(Column Column);
        Task<Column> FindByIdAsync(int id);
        void Update(Column Column);
        void Remove(Column Column);
    }
}