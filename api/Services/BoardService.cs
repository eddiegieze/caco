using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Repositories;

namespace Caco.API.Services
{
    public class BoardService : IBoardService
    {
        private IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<IEnumerable<Board>> ListBoardsAsync()
        {
            return await _boardRepository.ListAsync();
        }
    }
}