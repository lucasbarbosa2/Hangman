using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Xml.Linq;

namespace Core.Entities
{
    public class HangmanWords : IHangmanWords
    {
        private readonly IWebHostEnvironment _environment;
        public HangmanWords(IWebHostEnvironment webHostEnvironment) 
        {
            _environment = webHostEnvironment;          
        }
        public IList<string> GetWords()
        {
            IList<string> Words = new List<string>();

            XElement RootNode = XElement.Load(Path.Combine(_environment.WebRootPath,"Files/Words.xml"));

            //XElement RootNode = XElement.Load(Path.Combine(Path.GetFullPath("wwwroot"),"Files/Words.xml"));
            foreach (XElement word_lists in RootNode.Elements())
            {
                foreach (XElement word in word_lists.Elements())
                {
                    if (word.Name.LocalName.Equals("word"))
                    {
                        Words.Add(word.Value.ToString().ToUpper());
                    }
                }
            }

            return Words;
        }        
    }
}
