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
    [Route("cards")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardController(ILogger<CardController> logger, ICardService cardService, IMapper mapper)
        {
            _logger = logger;
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var card = await _cardService.GetAsync(id);
            var resource = _mapper.Map<Card, CardResource>(card);

            return Ok(resource);
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
