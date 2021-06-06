using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Caco.API.Extensions;
using Caco.API.Models;
using Caco.API.Resources;
using Caco.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Caco.API.Controllers
{
    [ApiController]
    [Route("boards")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardService _boardService;
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;

        public BoardController(ILogger<BoardController> logger, IBoardService boardService, IMapper mapper, IColumnService columnService)
        {
            _logger = logger;
            _boardService = boardService;
            _columnService = columnService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BoardResource>> GetAsync()
        {
            var boards = await _boardService.ListBoardsAsync();
            var resources = _mapper.Map<IEnumerable<Board>, IEnumerable<BoardResource>>(boards);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBoardResource saveBoardResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var board = _mapper.Map<SaveBoardResource, Board>(saveBoardResource);
            var result = await _boardService.SaveAsync(board);

            if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBoardResource saveBoardResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var board = _mapper.Map<SaveBoardResource, Board>(saveBoardResource);
            var result = await _boardService.UpdateAsync(id, board);

            if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _boardService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }


        [HttpGet("{id}/columns")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!await _boardService.Exists(id))
            {
                return NotFound("Board not found.");
            }
            var columns = await _columnService.ListColumnsAsync(id);
            var resources = _mapper.Map<IEnumerable<Column>, IEnumerable<ColumnResource>>(columns);

            return Ok(resources);
        }

        [HttpPost("{id}/columns")]
        public async Task<IActionResult> PostAsync(int id, [FromBody] SaveColumnResource saveColumnResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            if (!await _boardService.Exists(id))
            {
                return NotFound("Board not found.");
            }
            var column = _mapper.Map<SaveColumnResource, Column>(saveColumnResource);
            var result = await _columnService.SaveAsync(id, column);

            if (!result.Success)
                return BadRequest(result.Message);

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }
    }
}
