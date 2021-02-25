namespace Homework
{
    class Complex
    {
        private double Re;
        private double Im;

        public Complex()
        {
            this.Re = 0;
            this.Im = 0;
        }

        public Complex(double x, bool RealOrImaginary)
        {
            if (RealOrImaginary)
                this.Re = x;
            else
                this.Im = x;
        }

        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public Complex getValue()
        {
            return this;
        }

        public void setValue(Complex z)
        {
            this.Re = z.Re;
            this.Im = z.Im;
        }

        public void setValue(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public static Complex operator +(Complex z1, Complex z2)
        {
            Complex r = new Complex();
            r.Re = z1.Re + z2.Re;
            r.Im = z1.Im + z2.Im;
            return r;
        }

        public static Complex operator -(Complex z1, Complex z2)
        {
            Complex r = new Complex();
            r.Re = z1.Re - z2.Re;
            r.Im = z1.Im - z2.Im;
            return r;
        }

        public static Complex operator *(Complex z1, Complex z2)
        {
            Complex r = new Complex();
            r.Re = z1.Re * z2.Re - z1.Im * z2.Im;
            r.Im = z1.Re * z2.Im + z1.Im * z2.Re;
            return r;
        }

        public override string ToString()
        {
            if (this.Im < 0)
                return $"{this.Re} - {-this.Im}i";
            else if (this.Re == 0 && this.Im != 0)
                return $"{this.Im}";
            else if (this.Im == 0)
                return $"{this.Re}";
            else
                return $"{this.Re} + {this.Im}i";
        }
    }
}
