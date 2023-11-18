using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HangmanGuess
    {
        [Required, RegularExpression("\\A[^\\W\\d_]+\\z", ErrorMessage = "Your guess must be a letter!")]
        public string Guess { get; set; }
    }
}
