using System;

namespace Homework
{
    class Fraction
    {
        private int numerator;
        private int denomenator;

        public Fraction()
        {
            this.numerator = 0;
            this.denomenator = 1;
        }

        public Fraction(int n, int d)
        {
            // Add exception
            this.numerator = n;
            if (d != 0)
                this.denomenator = d;
            else
                throw new ArgumentException(String.Format("division on {0} in fractions", d),
                                      "denomenator"); ;
        }

        public int getNumerator()
        {
            return this.numerator;
        }

        public void setNumerator(int n)
        {
            this.numerator = n;
        }

        public int getDenomenator()
        {
            return this.denomenator;
        }

        public void setDenomenator(int d)
        {
            //exception
            if (d != 0)
                this.denomenator = d;
            else
                throw new ArgumentException(String.Format("division on {0} in fractions", d),
                                      "denomenator"); ;
        }

        public Fraction getFraction()
        {
            return this;
        }

        public double getDecimalFromFraction()
        {
            return double.Parse((this.numerator / this.denomenator).ToString("0.00"));
        }

        public void setFraction(int n, int d)
        {
            this.numerator = n;
            if (d != 0)
                this.denomenator = d;
            else
                throw new ArgumentException(String.Format("division on {0} in fractions", d),
                                      "denomenator"); ;
        }

        public override string ToString()
        {
            if (this.denomenator == 1)
                return $"{this.numerator}";
            else if (this.denomenator < 0)
                return $"-{this.numerator}/{-this.denomenator}";
            else
                return $"{this.numerator}/{this.denomenator}";
        }

        private static int NOD(int a, int b)
        {
            while (a != b)
                if (a > b) a -= b;
                else b -= a;
            return a;
        }

        public static Fraction operator +(Fraction z1, Fraction z2)
        {
            Fraction r = new Fraction();
            r.numerator = z1.numerator * z2.denomenator + z2.numerator * z1.denomenator;
            r.denomenator = z1.denomenator * z2.denomenator;
            int nod = NOD(r.numerator, r.denomenator);
            r.numerator /= nod;
            r.denomenator /= nod;
            return r;
        }

        public static Fraction operator -(Fraction z1, Fraction z2)
        {
            Fraction r = new Fraction();
            r.numerator = z1.numerator * z2.denomenator - z2.numerator * z1.denomenator;
            r.denomenator = z1.denomenator * z2.denomenator;
            int nod = NOD(r.numerator, r.denomenator);
            r.numerator /= nod;
            r.denomenator /= nod;
            return r;
        }

        public static Fraction operator *(Fraction z1, Fraction z2)
        {
            Fraction r = new Fraction();
            r.numerator = z1.numerator * z2.numerator;
            r.denomenator = z1.denomenator * z2.denomenator;
            int nod = NOD(r.numerator, r.denomenator);
            r.numerator /= nod;
            r.denomenator /= nod;
            return r;
        }

        public static Fraction operator /(Fraction z1, Fraction z2)
        {
            Fraction r = new Fraction();
            r.numerator = z1.numerator * z2.denomenator;
            r.denomenator = z1.denomenator * z2.numerator;
            int nod = NOD(r.numerator, r.denomenator);
            r.numerator /= nod;
            r.denomenator /= nod;
            return r;
        }

    }
}
