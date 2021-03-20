using System;
using System.Collections.Generic;
using System.Text;

//класс реализации интерфейса с моделью
namespace BelieveOrNotBelieve
{
    public class Start
    {
        TrueFalse trueFalse;
        IView view;
        
        public Start(IView view)
        {
            this.view = view;
            trueFalse = new TrueFalse();
        }
        public void ViewQuestion()
        {
            view.Question = trueFalse[view.Number - 1].Text;
            view.Check = trueFalse[view.Number - 1].TrueFalse;
        }
        public void New(string filename)
        {
            trueFalse = new TrueFalse(filename);
            trueFalse.Add("123", true);
            trueFalse.Save();
            view.Number = 1;
            view.Max = 1;
            view.Min = 1;
        }
        public string Add()
        {
            if (trueFalse == null) return "Create new database";
            trueFalse.Add((trueFalse.Count + 1).ToString(), true);
            view.Max = trueFalse.Count;
            view.Number = trueFalse.Count;
            return "OK";
        }
        public void Delete()
        {
            if (view.Max == 1 || trueFalse == null) return;
            trueFalse.Remove(view.Number);
            view.Max--;
            if (view.Number > 1)
                view.Number = view.Number;
        }
        public string Save()
        {
            if (trueFalse != null)
                trueFalse.Save();
            else
                return "Database is not created.";
            return "OK";
        }
        public void Open(string filename)
        {
            trueFalse = new TrueFalse(filename);
            trueFalse.Load();
            view.Max = trueFalse.Count;
            view.Min = 1;
            view.Number = 1;
        }
        public void SaveQuestion()
        {
            trueFalse[view.Number - 1].Text = view.Question;
            trueFalse[view.Number - 1].TrueFalse = view.Check;
        }
        public string SaveAs(string filename)
        {
            if (trueFalse != null)
            {
                trueFalse.Filename = filename;
                trueFalse.Save();
            }
            else
                return "Database is not created";
            return "OK";
        }
    }
}
