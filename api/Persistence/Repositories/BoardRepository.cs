using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Persistence.Contexts;

namespace Caco.API.Persistence.Repositories
{
    public class BoardRepository : BaseRepository, IBoardRepository
    {
        public BoardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Board>> ListAsync()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task AddAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }

        public async Task<Board> FindByIdAsync(int id)
        {
            return await _context.Boards.FindAsync(id);
        }

        public void Update(Board board)
        {
            _context.Boards.Update(board);
        }
    }
}