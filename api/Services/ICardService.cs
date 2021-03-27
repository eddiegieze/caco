using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public interface ICardService
    {
         public Task<IEnumerable<Card>> ListCardsAsync(int columnId);
         Task<CardResponse> SaveAsync(int columnId, Card card);
         Task<CardResponse> UpdateAsync(int id, Card card);
         Task<CardResponse> DeleteAsync(int id);
    }
}