using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;

namespace CashlessTokenChallenge.API.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDTO GenerateToken(Card cardModel);
        Token FindTokenByCardId(int cardId);
        TokenValidatedDTO ValidateToken(Token tokenModel, TokenValidationDTO dto);
    }
}
