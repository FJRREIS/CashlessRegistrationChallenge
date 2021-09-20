using System.ComponentModel.DataAnnotations;

namespace CashlessTokenChallenge.Models.DTOs
{
    public class CardDTO
    {
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public long? CardNumber { get; set; }
        [Required]
        public int? CVV { get; set; }
    }
}
