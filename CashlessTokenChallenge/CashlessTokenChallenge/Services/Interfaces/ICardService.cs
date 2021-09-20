using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;

namespace CashlessTokenChallenge.API.Services.Interfaces
{
    public interface ICardService
    {
        TokenDTO SaveCard(Card cardModel);
    }
}
