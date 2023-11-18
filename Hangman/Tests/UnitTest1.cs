using Infrastructure.Services;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReadXmlFile()
        {
            var HangmanService = new HangmanService();

            var hangmanDTO = HangmanService.SetChosenWord();

            Assert.NotNull(hangmanDTO);
            Assert.NotEmpty(hangmanDTO.GuessedWord);
        }

        [Fact]
        public void EmptyGuessWontCount()
        {
            var HangmanService = new HangmanService();

            var hangmanDTO = HangmanService.SetChosenWord();

            var prevRemAttempts = hangmanDTO.RemainingAttempts;

            hangmanDTO = HangmanService.CheckLetter(hangmanDTO, new Core.Entities.HangmanGuess());

            Assert.Equal(prevRemAttempts, hangmanDTO.RemainingAttempts);
        }

        [Fact]
        public void OneGuessIsOneAttempt()
        {
            var HangmanService = new HangmanService();

            var hangmanDTO = HangmanService.SetChosenWord();

            var prevRemAttempts = hangmanDTO.RemainingAttempts;

            hangmanDTO = HangmanService.CheckLetter(
                hangmanDTO,
                new Core.Entities.HangmanGuess { Guess = "A"});

            Assert.True(prevRemAttempts-hangmanDTO.RemainingAttempts == 1);
        }

        [Fact]
        public void OneWordGuessIsOneAttempt()
        {
            {
                var HangmanService = new HangmanService();

                var hangmanDTO = HangmanService.SetChosenWord();

                var prevRemAttempts = hangmanDTO.RemainingAttempts;

                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "Open" });

                Assert.True(prevRemAttempts - hangmanDTO.RemainingAttempts == 1);
            }
        }

        [Fact]
        public void ExausthingAttemptsLose()
        {
            {
                var HangmanService = new HangmanService();

                var hangmanDTO = HangmanService.SetChosenWord();

                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });
                hangmanDTO = HangmanService.CheckLetter(
                    hangmanDTO,
                    new Core.Entities.HangmanGuess { Guess = "A" });

                Assert.True(hangmanDTO.Stage == Application.DTO.Stages.Lose);
            }
        }
    }
}