using System;

namespace Practice
{
    class Point
    {
        private double x;
        private double y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double getX()
        {
            return this.x;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getY()
        {
            return this.y;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public Point getPoint()
        {
            return this;
        }

        public void setPoint(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));
        }

        public override string ToString()
        {
            return $"p = ({this.x},{this.y})";
        }
    }
}
