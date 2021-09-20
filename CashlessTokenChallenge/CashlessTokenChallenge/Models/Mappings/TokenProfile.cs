using AutoMapper;
using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;

namespace CashlessTokenChallenge.Mappings
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenDTO>()
                .ForMember(dest => dest.Token,
                           opts => opts.MapFrom(src => src.TokenNumber));
        }
    }
}
