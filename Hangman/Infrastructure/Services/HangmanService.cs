using Application.DTO;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class HangmanService : IHangmanService
    {
        private static Random Random = new Random();
        private int Attempts { get; set; }
        private readonly int MaxAttempts = 7;
        private string ChosenWord { get; set; } = string.Empty;
        private IHangmanWords HangmanWords { get; set; }

        public HangmanService(IHangmanWords hangmanWords)
        {
            HangmanWords = hangmanWords;
        }

        public HangmanDTO SetChosenWord()
        {
            Attempts = 0;

            var words = HangmanWords.GetWords();

            ChosenWord = words[Random.Next(words.Count)];

            HangmanDTO hangmanDTO = new HangmanDTO
            {
                RemainingAttempts = MaxAttempts,

                GuessedWord = string.Concat(Enumerable.Repeat("_", ChosenWord.Length))
            };

            return hangmanDTO;
        }

        public HangmanDTO SetWordForTest(string word)
        {
            Attempts = 0;

            var words = HangmanWords.GetWords();

            ChosenWord = word;

            HangmanDTO hangmanDTO = new HangmanDTO
            {
                RemainingAttempts = MaxAttempts,

                GuessedWord = string.Concat(Enumerable.Repeat("_", ChosenWord.Length))
            };

            return hangmanDTO;
        }

        public HangmanDTO CheckLetter(HangmanDTO HangmanDTO, HangmanGuess hangmanGuess)
        {
            if (hangmanGuess != null && !string.IsNullOrEmpty(hangmanGuess.Guess))
            {
                Attempts++;

                HangmanDTO.RemainingAttempts = GetRemainingAttempts();
                if (hangmanGuess.Guess.Length > 1)
                {
                    if (hangmanGuess.Guess.ToUpper().Equals(ChosenWord))
                    {
                        HangmanDTO.GuessedWord = ChosenWord;
                    }
                }
                else
                {
                    var charArray = hangmanGuess.Guess.ToUpper().ToCharArray();

                    for (int i = 0; i < ChosenWord.Length; i++)
                    {
                        if (ChosenWord[i] == charArray[0])
                            HangmanDTO.GuessedWord = HangmanDTO.GuessedWord.Remove(i, 1).Insert(i, charArray[0].ToString());
                    }
                }

                if (HangmanDTO.GuessedWord == ChosenWord)
                {
                    HangmanDTO.Stage = Stages.Won;
                }

                else
                {
                    HangmanDTO.Stage = HangmanDTO.RemainingAttempts > 0 ? Stages.Playing : Stages.Lose;
                }

                if (HangmanDTO.Stage.Equals(Stages.Won) || HangmanDTO.Stage.Equals(Stages.Lose))
                {
                    HangmanDTO.GuessedWord = ChosenWord;
                }
            }

            return HangmanDTO;
        }

        private int GetRemainingAttempts()
        {
            return MaxAttempts - Attempts;
        }
    }
}
