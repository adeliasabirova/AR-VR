using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumberClass
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

        public void Play()
        {
            view.CheckGoal = $"{ model.Play()}";
        }

        public void Check()
        {
            model.Number = view.Number;
            view.CheckGoal = $"{model.Check()}";
        }
    }
}
