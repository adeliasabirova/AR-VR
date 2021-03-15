using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClass
{
    public class Model
    {
        int a, b;
        public string S1 { get; set; }
        public string S2 { get; set; }

        private bool Check() => int.TryParse(S1, out a) && int.TryParse(S2, out b);

        public string Sum() => Check() ? $"{a}+{b} = {a + b}" : "Error";
        
    }
}
