using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishWordsClass
{
    public interface IView
    {
        string Word { get; }
        List<String> Glossary { set; }
        int Index { get; }

    }
}
