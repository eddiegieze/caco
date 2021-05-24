using System.Threading.Tasks;
using Caco.API.Repositories;
using Caco.API.Persistence.Contexts;

namespace Caco.API.Persistence.Repositories
{
    public class ChangeSet : IChangeSet
    {
        private readonly AppDbContext _context;

        public ChangeSet(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}