using System;
using System.Collections.Generic;
using System.Text;

namespace PowerClass
{
    /// <summary>
    /// обработчик
    /// </summary>
    public class Presenter
    {
        Model model;
        IView view;

        public Presenter(IView view)
        {
            this.view = view;
            model = new Model();
        }

        public void Reset()
        {
            model.S = view.Number;
            view.Number = $"{model.Reset()}";
        }

        public void Plus1()
        {
            model.S = view.Number;
            view.Number = $"{model.Plus1()}";
        }

        public void X2()
        {
            model.S = view.Number;
            view.Number = $"{model.X2()}";
        }

        public void ShowCount()
        {
            view.Count = $"{model.ShowCount()}";
        }

        public void ShowGoal()
        {
            model.Play();
            view.Goal = $"{model.Goal}";
        }

        public void Cancel()
        {
            model.S = view.Number;
            string str = model.Cancel();
            if (str != "Error")
                view.Number = str;
        }

    }
}
