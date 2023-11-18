using System.Xml.Linq;

namespace Core.Entities
{
    public static class HangmanWords
    {
        public static IList<string> GetWords()
        {
            IList<string> Words = new List<string>();

            XElement RootNode = XElement.Load(Path.Combine(AppContext.BaseDirectory,"/WebUI/wwwroot/Files/Words.xml"));
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
