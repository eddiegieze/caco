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
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService _cardService;
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;

        public CardController(ILogger<CardController> logger, ICardService cardService, IMapper mapper, IColumnService columnService)
        {
            _logger = logger;
            _cardService = cardService;
            _columnService = columnService;
            _mapper = mapper;
        }

        [HttpGet("{columnId}")]
        public async Task<IActionResult> GetAsync(int columnId)
        {
            if (!await _columnService.Exists(columnId))
            {
                return NotFound("Column not found.");
            }
            var cards = await _cardService.ListCardsAsync(columnId);
            var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(cards);

            return Ok(resources);
        }

        [HttpPost("{columnId}")]
        public async Task<IActionResult> PostAsync(int columnId, [FromBody] SaveCardResource saveCardResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var card = _mapper.Map<SaveCardResource, Card>(saveCardResource);
            var result = await _cardService.SaveAsync(columnId, card);

            if (!result.Success)
                return BadRequest(result.Message);

            var cardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(cardResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCardResource saveCardResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var card = _mapper.Map<SaveCardResource, Card>(saveCardResource);
            var result = await _cardService.UpdateAsync(id, card);

            if (!result.Success)
                return BadRequest(result.Message);

            var cardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(cardResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _cardService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var cardResource = _mapper.Map<Card, CardResource>(result.Card);
            return Ok(cardResource);
        }
    }
}
