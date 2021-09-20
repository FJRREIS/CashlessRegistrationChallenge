using System.ComponentModel.DataAnnotations;

namespace CashlessTokenChallenge.Models.DTOs
{
    public class TokenValidationDTO
    {
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public int? CardId { get; set; }
        [Required]
        public long? Token { get; set; }
        [Required]
        public int? CVV { get; set; }
    }
}
