using System;

namespace CashlessTokenChallenge.Models.DTOs
{
    public class TokenDTO
    {
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public int CardId { get; set; }
    }
}
