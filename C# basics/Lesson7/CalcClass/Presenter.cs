using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClass
{
    public class Presenter
    {
        Model model;
        IView view;

        public Presenter(IView view)
        {
            this.view = view;
            model = new Model();
        }

        public void Sum()
        {
            model.S1 = view.Numb1;
            model.S2 = view.Numb2;
            view.Result = $"{model.Sum()}";
        }
    }
}
