namespace CashlessTokenChallenge.Models.DTOs
{
    public class TokenValidatedDTO
    {
        public TokenValidatedDTO(bool validated)
        {
            Validated = validated;
        }
        public bool Validated { get; set; }
    }
}
