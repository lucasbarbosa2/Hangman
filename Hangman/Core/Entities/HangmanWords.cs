using System.IO;
using System.Xml.Linq;

namespace Core.Entities
{
    public static class HangmanWords
    {
        public static IList<string> GetWords()
        {
            IList<string> Words = new List<string>();

            //XElement RootNode = XElement.Load(Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,"wwwroot/Files/Words.xml"));
            XElement RootNode = XElement.Load(Path.Combine(Path.GetFullPath("wwwroot"),"Files/Words.xml"));
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
