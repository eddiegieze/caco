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
    [Route("[controller]")]
    public class ColumnController : ControllerBase
    {
        private readonly ILogger<ColumnController> _logger;
        private readonly IColumnService _columnService;
        private readonly IBoardService _boardService;
        private readonly IMapper _mapper;

        public ColumnController(ILogger<ColumnController> logger, IColumnService columnService, IMapper mapper, IBoardService boardService)
        {
            _logger = logger;
            _columnService = columnService;
            _mapper = mapper;
            _boardService = boardService;
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetAsync(int boardId)
        {
            if (! await _boardService.Exists(boardId))
            {
                return NotFound("Board not found.");
            }
            var columns = await _columnService.ListColumnsAsync(boardId);
            var resources = _mapper.Map<IEnumerable<Column>, IEnumerable<ColumnResource>>(columns);

            return Ok(resources);
        }

        [HttpPost("{boardId}")]
        public async Task<IActionResult> PostAsync(int boardId, [FromBody] SaveColumnResource saveColumnResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var column = _mapper.Map<SaveColumnResource, Column>(saveColumnResource);
            var result = await _columnService.SaveAsync(boardId, column);

            if (!result.Success)
                return BadRequest(result.Message);

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveColumnResource saveColumnResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var column = _mapper.Map<SaveColumnResource, Column>(saveColumnResource);
            var result = await _columnService.UpdateAsync(id, column);

            if (!result.Success)
                return BadRequest(result.Message);

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _columnService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }
    }
}
