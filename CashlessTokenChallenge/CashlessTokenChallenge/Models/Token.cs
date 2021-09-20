using CashlessTokenChallenge.Models.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashlessTokenChallenge.Models
{
    public class Token
    {
        public Token()
        {
        }

        public Token(int cardId, long tokenNumber, double minToExpire)
        {
            CardId = cardId;
            TokenNumber = tokenNumber;
            RegistrationDate = DateTime.UtcNow;
            ExpireDate = DateTime.UtcNow.AddMinutes(minToExpire);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CardId { get; set; }
        public long TokenNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Card Card { get; set; }

        public bool ValidateToken(TokenValidationDTO validationDTO)
        {
            //Check if the token has expired
            if (DateTime.UtcNow > ExpireDate)
                return false;

            //Check if the customerId sent is the same as in card registration
            if (Card.CustomerId != validationDTO.CustomerId)
                return false;

            //Print card number to console
            Console.WriteLine($"Card number: {Card.CardNumber}");

            //Generate token again to compare with sent token
            var tokenNumber = Card.GenerateToken(validationDTO.CVV);
            if (tokenNumber != validationDTO.Token)
                return false;

            return true;
        }
    }
}
