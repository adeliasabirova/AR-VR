using System;

namespace BelieveOrNotBelieve
{
    //класс с вопросами
    public class Question
    {
        string text;
        bool trueFalse;
        public string Text { get => text; set => text = value; }
        public bool TrueFalse { get => trueFalse; set => trueFalse = value; }
        public Question() { }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
}
