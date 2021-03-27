using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Persistence.Contexts;
using System.Linq;

namespace Caco.API.Persistence.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Card>> ListAsync(int columnId)
        {
            return await _context.Cards.Where(c => c.ColumnId == columnId).ToListAsync();
        }

        public async Task AddAsync(Card Card)
        {
            await _context.Cards.AddAsync(Card);
        }

        public async Task<Card> FindByIdAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public void Update(Card card)
        {
            _context.Cards.Update(card);
        }

        public void Remove(Card card)
        {
            _context.Cards.Remove(card);
        }
    }
}