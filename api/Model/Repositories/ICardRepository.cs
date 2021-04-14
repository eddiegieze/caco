using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;

namespace Caco.API.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> ListAsync(int columnId);
        Task AddAsync(Card card);
        Task<Card> FindByIdAsync(int id);
        void Update(Card card);
        void Remove(Card card);
    }
}