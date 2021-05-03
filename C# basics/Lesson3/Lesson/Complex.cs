namespace Lesson
{
    struct Complex
    {
        public double Re, Im;

        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public string Print()
        {
            if (Im < 0)
                return $"{Re} - {-Im}i";
            else if (Im == 0)
                return $"{Re}";
            else
                return $"{Re} + {Im}i";
        }

        public Complex Sum(Complex z)
        {
            Complex r = new Complex();
            r.Re = z.Re + this.Re;
            r.Im = z.Im + this.Im;
            return r;
        }
        public static Complex operator +(Complex z1, Complex z2)
        {
            Complex r = new Complex();
            r.Re = z1.Re + z2.Re;
            r.Im = z1.Im + z2.Im;
            return r;
        }
        public static Complex Sum(Complex z1, Complex z2)
        {
            Complex r = new Complex();
            r.Re = z1.Re + z2.Re;
            r.Im = z1.Im + z2.Im;
            return r;
        }
    }
}
