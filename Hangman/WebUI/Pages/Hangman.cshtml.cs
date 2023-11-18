using Application.DTO;
using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class HangmanModel : PageModel
    {
        public IHangmanService HangmanService { get; set; }        

        [BindProperty]
        public HangmanGuess HangmanGuess { get; set; }

        [BindProperty]
        public HangmanDTO HangmanDTO { get; set; }

        [BindProperty]
        public string? Attempted { get; set; }

        public HangmanModel(IHangmanService hangmanService)
        {            
            HangmanService = hangmanService;
        }

        public void OnGet()
        {
            HangmanDTO = HangmanService.SetChosenWord();            
        }

        public void OnPostTakeGuess()
        {
            if (ModelState.IsValid)
            {
                if(HangmanGuess.Guess.Length == 1)
                    Attempted += HangmanGuess.Guess;
                ModelState.Clear();
                HangmanDTO = HangmanService.CheckLetter(HangmanDTO, HangmanGuess);
                HangmanGuess.Guess = string.Empty;
            }
        }

        public void OnPostRestart()
        {
            HangmanDTO = HangmanService.SetChosenWord();
        }
    }
}
