using System.Runtime;

namespace Application.DTO
{
    public class HangmanDTO
    {
        public string GuessedWord { get; set; }

        public int RemainingAttempts { get; set; }

        public Stages Stage { get; set; } = 0;
    }

    public enum Stages
    {
        Playing = 0,
        Won = 1,
        Lose = 2
    }
}
