using Application.DTO;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IHangmanService
    {
        public HangmanDTO SetChosenWord();

        public HangmanDTO CheckLetter(HangmanDTO HangmanDTO, HangmanGuess hangmanGuess);
    }
}
