using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace EnglishWordsClass
{
    //класс реализации словоря со словами, основанные на классе TrueFalse
    public class Glossary
    {
        string filename;
        List<Word> glossary;
        public string Filename { set { filename = value; } }
        public Glossary() { }
        public Glossary(string filename)
        {
            this.filename = filename;
            glossary = new List<Word>();
        }
        public void Add(string text)
        {
            string[] str = text.Replace(" ", "").Split('-');
            glossary.Add(new Word(str[0],str[1]));
        }
        public void Remove(int index)
        {
            if (glossary != null && index < glossary.Count && index >= 0)
                glossary.RemoveAt(index);
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Word>));
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, glossary);
            fStream.Close();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Word>));
            Stream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            glossary = (List<Word>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public int Count
        {
            get { return glossary.Count; }
        }
        public List<string> GlossaryToString()
        {
            List<string> gl = new List<string>();
            foreach(var word in glossary)
            {
                gl.Add(word.ToString());
            }
            return gl;
        }
    }
}
