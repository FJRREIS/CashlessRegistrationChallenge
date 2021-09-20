namespace CashlessTokenChallenge.Models.DTOs
{
    public class ErrorDTO
    {
        public ErrorDTO(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
