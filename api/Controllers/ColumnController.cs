using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Caco.API.Extensions;
using Caco.API.Models;
using Caco.API.Resources;
using Caco.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caco.API.Controllers
{
    [ApiController]
    [Route("columns")]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnService _columnService;
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public ColumnController(IColumnService columnService, IMapper mapper, ICardService cardService)
        {
            _columnService = columnService;
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveColumnResource saveColumnResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var column = _mapper.Map<SaveColumnResource, Column>(saveColumnResource);
            var result = await _columnService.UpdateAsync(id, column);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _columnService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var columnResource = _mapper.Map<Column, ColumnResource>(result.Column);
            return Ok(columnResource);
        }

        [HttpGet("{id}/cards")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!await _columnService.Exists(id))
            {
                return NotFound("Column not found.");
            }
            var cards = await _cardService.ListCardsAsync(id);
            var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(cards);

            return Ok(resources);
        }

        [HttpPost("{id}/cards")]
        public async Task<IActionResult> PostAsync(int id, [FromBody] SaveCardResource saveCardResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            if (!await _columnService.Exists(id))
            {
                return NotFound("Column not found.");
            }
            var card = _mapper.Map<SaveCardResource, Card>(saveCardResource);
            var result = await _cardService.SaveAsync(id, card);

            if (!result.Success)
                return BadRequest(result.Message);

            var cardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(cardResource);
        }
    }
}
