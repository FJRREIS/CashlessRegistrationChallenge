using AutoMapper;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;

namespace CashlessTokenChallenge.Mappings
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardDTO, Card>();
            CreateMap<TokenValidationDTO, Card>();
        }
    }
}
