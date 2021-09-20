using System;
using System.ComponentModel.DataAnnotations;

namespace CashlessTokenChallenge.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required]
        [Range(0, 9999999999999999)]
        public long CardNumber { get; set; }
        [Required]
        [Range(0, 99999)]
        public int CVV { get; set; }
        public DateTime RegistrationDate { get; set; }

        public long GenerateToken(int? cvv = null)
        {
            //gets the card's last 4 digits
            var cardString = CardNumber.ToString();
            //if cardnumber has less then 4 digits, fill the string with zeros on the left side
            if (cardString.Length < 4)
                cardString = cardString.PadLeft(4, '0');

            var cardLastDigits = cardString.Substring(cardString.Length - 4);
            //gets the minimium number of shifts to perform - if the cvv is not passed by parameter, the CVV property is used
            var shifts = cvv??CVV;
            shifts = shifts % cardLastDigits.Length;
            //Verifies if shits are needed
            if (shifts > 0)
            {
                //Interpolates the two substrings resulting from right shifting the string 
                var tokenString = $"{cardLastDigits.Substring(cardLastDigits.Length - shifts)}{cardLastDigits.Substring(0, cardLastDigits.Length - shifts)}";
                return long.Parse(tokenString);
            } 
            else //In case no shifts are performed, returns tha card's last 4 digits
                return long.Parse(cardLastDigits);
        }
    }
}
