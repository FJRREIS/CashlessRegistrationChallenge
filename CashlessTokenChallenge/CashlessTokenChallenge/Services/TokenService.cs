using AutoMapper;
using CashlessTokenChallenge.API.Services.Interfaces;
using CashlessTokenChallenge.Data;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CashlessTokenChallenge.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;
        private readonly IOptions<TokenSettings> _appSettings;

        public TokenService(IMapper mapper, DataContext dbContext, IOptions<TokenSettings> appSettings)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _appSettings = appSettings;
        }

        public TokenDTO GenerateToken(Card cardModel)
        {
            //Generate token number
            var tokenNumber = cardModel.GenerateToken();

            //Retrieve token settings
            var minToExpire = _appSettings.Value.MinutesToExpiration;

            //Saves token to db
            var tokenModel = new Token(cardModel.Id, tokenNumber, minToExpire);
            _dbContext.Tokens.Add(tokenModel);
            _dbContext.SaveChanges();

            var tokenDto = _mapper.Map<TokenDTO>(tokenModel);
            return tokenDto;
        }

        public Token FindTokenByCardId(int cardId)
        {
            return _dbContext.Tokens.Include(c => c.Card).FirstOrDefault(c => c.CardId == cardId);
        }

        public TokenValidatedDTO ValidateToken(Token tokenModel, TokenValidationDTO dto)
        {
            var isValid = tokenModel.ValidateToken(dto);

            var validatedDto = new TokenValidatedDTO(isValid);
            return validatedDto;
        }
    }
}
