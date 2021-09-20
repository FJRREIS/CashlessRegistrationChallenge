using CashlessTokenChallenge.API.Services.Interfaces;
using CashlessTokenChallenge.Data;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;
using System;

namespace CashlessTokenChallenge.API.Services
{
    public class CardService : ICardService
    {
        private readonly DataContext _dbContext;
        private readonly ITokenService _tokenService;

        public CardService(DataContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public TokenDTO SaveCard (Card cardModel)
        {
            //Insert card on DB
            cardModel.RegistrationDate = DateTime.UtcNow;
            _dbContext.Cards.Add(cardModel);
            _dbContext.SaveChanges();

            //Create token
            var tokenDTO = _tokenService.GenerateToken(cardModel);

            return tokenDTO;
        }
    }
}
