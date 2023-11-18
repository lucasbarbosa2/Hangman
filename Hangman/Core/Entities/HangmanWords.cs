using System.IO;
using System.Xml.Linq;

namespace Core.Entities
{
    public static class HangmanWords
    {
        public static IList<string> GetWords()
        {
            IList<string> Words = new List<string>();

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            XElement RootNode = XElement.Load(Path.Combine(workingDirectory, "WebUI/wwwroot/Files/Words.xml"));
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
