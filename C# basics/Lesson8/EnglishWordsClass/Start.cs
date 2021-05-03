using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishWordsClass
{
    //класс реализации интерфейса с моделью словаря
    public class Start
    {
        Glossary glossary;
        IView view;
        public Start(IView view)
        {
            this.view = view;
            glossary = new Glossary();
        }
        public void ViewGlossary()
        {
            view.Glossary = glossary.GlossaryToString();
        }
        public void New(string filename)
        {
            glossary = new Glossary(filename);
            //glossary.Add("default-начальное");
        }
        public string Add()
        {
            if (glossary == null) return "Create new database";
            glossary.Add(view.Word);
            return "OK";
        }
        public void Delete()
        {
            if (glossary == null) return;
            if (view.Index == 0) return;
            else if (view.Index <= glossary.Count)
                glossary.Remove(view.Index - 1);
            else return;
        }
        public string Save()
        {
            if (glossary != null)
                glossary.Save();
            else
                return "Database is not created.";
            return "OK";
        }
        public void Open(string filename)
        {
            glossary = new Glossary(filename);
            glossary.Load();
        }
        public string SaveAs(string filename)
        {
            if (glossary != null)
            {
                glossary.Filename = filename;
                glossary.Save();
            }
            else
                return "Database is not created";
            return "OK";
        }
    }
}
