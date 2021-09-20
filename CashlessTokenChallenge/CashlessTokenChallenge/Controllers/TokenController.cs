using AutoMapper;
using CashlessTokenChallenge.API.Services.Interfaces;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace CashlessTokenChallenge.Controllers
{
    [ApiController]
    [Route("v1/token")]
    public class TokenController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public TokenController(IMapper mapper, ITokenService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Validate token for customer card
        /// </summary>
        /// <response code="200">Returns the token validation result</response>
        [HttpPost]
        [Route("validate")]
        public ActionResult<TokenValidatedDTO> Post([FromBody] TokenValidationDTO dto)
        {
            var tokenModel = _tokenService.FindTokenByCardId(dto.CardId.Value);
            if (tokenModel == null)
                return NotFound(new ErrorDTO("Card not found."));

            //Creates a card model for input validation
            var cardModelFromDto = _mapper.Map<Card>(dto);
            cardModelFromDto.CardNumber = tokenModel.Card.CardNumber;

            if (TryValidateModel(cardModelFromDto))
            {
                var validatedDto = _tokenService.ValidateToken(tokenModel, dto);
                return validatedDto;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
