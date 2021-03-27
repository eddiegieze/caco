using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Persistence.Contexts;
using System.Linq;

namespace Caco.API.Persistence.Repositories
{
    public class ColumnRepository : BaseRepository, IColumnRepository
    {
        public ColumnRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Column>> ListAsync(int boardId)
        {
            return await _context.Columns.Where(c => c.BoardId == boardId).ToListAsync();
        }

        public async Task AddAsync(Column Column)
        {
            await _context.Columns.AddAsync(Column);
        }

        public async Task<Column> FindByIdAsync(int id)
        {
            return await _context.Columns.FindAsync(id);
        }

        public void Update(Column Column)
        {
            _context.Columns.Update(Column);
        }

        public void Remove(Column Column)
        {
            _context.Columns.Remove(Column);
        }
    }
}