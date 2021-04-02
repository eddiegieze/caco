using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public interface IColumnService
    {
        public Task<IEnumerable<Column>> ListColumnsAsync(int boardId);
        Task<ColumnResponse> SaveAsync(int boardId, Column column);
        Task<ColumnResponse> UpdateAsync(int id, Column column);
        Task<ColumnResponse> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}