using AutoMapper;
using CashlessTokenChallenge.API.Services.Interfaces;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CashlessTokenChallenge.Controllers
{
    [ApiController]
    [Route("v1/card")]
    public class CardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICardService _cardService;
        public CardController(IMapper mapper, ICardService cardService)
        {
            _mapper = mapper;
            _cardService = cardService;
        }

        /// <summary>
        /// Save customer card on db
        /// </summary>
        /// <response code="200">Returns the created card</response>
        [HttpPost]
        [Route("")]
        public ActionResult<TokenDTO> Post([FromBody] CardDTO card)
        {
            var cardModel = _mapper.Map<Card>(card);

            if (TryValidateModel(cardModel))
            {
                var tokenDTO = _cardService.SaveCard(cardModel);

                return tokenDTO;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
