using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Observer
{
    //public delegate void MyDelegate(object o);
    public delegate void MyGenericDelegate<T>(T o);

    class Source<T>
    {
        public event MyGenericDelegate<T> Run;

        public void Start(T o)
        {
            Console.WriteLine("RUN");
            if (Run != null) Run(o);
        }
    }
    class Observer1<T> // Наблюдатель 1
    {
        public void Do(T o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
    }
    class Observer2<T> // Наблюдатель 2
    {
        public void Do(T o)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //решила создать не только общий делегат, но и общий класс

            Console.WriteLine("Object Delegate");
            Source<object> s = new Source<object>();
            Observer1<object> o1 = new Observer1<object>();
            Observer2<object> o2 = new Observer2<object>();
            MyGenericDelegate<object> d1 = new MyGenericDelegate<object>(o1.Do);
            s.Run += d1;
            s.Run += o2.Do;
            //мне не очень нравится, что в случаи объекта нужно передавать в метод объекта сам объект, но по-другому как-то не придумала
            s.Start(s);
            s.Run -= d1;
            s.Start(s);

            Console.WriteLine("\nString Delegate");
            Source<String> sString = new Source<String>();
            Observer1<String> o_str1 = new Observer1<String>();
            Observer2<String> o_str2 = new Observer2<String>();
            MyGenericDelegate<String> d_str1 = new MyGenericDelegate<String>(o_str1.Do);
            sString.Run += d_str1;
            sString.Run += o_str2.Do;
            sString.Start("Source");
            sString.Run -= d_str1;
            sString.Start("Source");
            Console.ReadKey();
        }
    }

}
