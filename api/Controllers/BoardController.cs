using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Caco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardService _boardService;

        public BoardController(ILogger<BoardController> logger, IBoardService boardService)
        {
            _logger = logger;
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IEnumerable<Board>> GetAsync()
        {
            var boards = await _boardService.ListBoardsAsync();
            return boards;
        }
    }
}
