using System;

namespace EnglishWordsClass
{
    //класс слов в форме английское слово - перевод
    public class Word
    {
        string english;
        string translation;
        public string English { get => english; set => english = value; }
        public string Translation { get => translation; set => translation = value; }
        public Word()
        {

        }
        public Word(string english, string translation)
        {
            this.english = english;
            this.translation = translation;
        }
        public override string ToString()
        {
            return $"{english} - {translation}";
        }
    }
}
