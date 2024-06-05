using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Complex
    {
        public static Complex Zero = new Complex(0, 0);
        public static Complex One = new Complex(1, 0);
        public static Complex ImaginaryOne = new Complex(0, 1);

        private double realpart;
        private double imagepart;

        public double Re()
        {
            return realpart;
        }

        public double Im()
        {
            return imagepart;
        }

        public static Complex Sqrt(double x)
        {
            if (x < 0)
            {
                double absX = Math.Sqrt(-x);
                return new Complex(0, absX);
            }
            else
            {
                double sqrtX = Math.Sqrt(x);
                return new Complex(sqrtX, 0);
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Complex(double x) : this(x, 0)
        {

        }

        public Complex() : this(0)
        {

        }

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.X + y.Y, x.Y + y.X);
        }

        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex(x.X - y.Y, x.Y - y.X);
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(x.X * y.Y - x.Y * y.X, x.X * y.Y + y.X * x.Y);
        }

        public static Complex operator /(Complex x, Complex y)
        {
            if (y.X == 0 && y.Y == 0)
            {
                throw new DivideByZeroException("Division by zero");
            }

            double denominator = y.X * y.X + y.Y * y.Y;
            double realpart = (x.X * y.X + x.Y * y.Y) / denominator;
            double imagepart = (x.Y * y.X + x.X * y.Y) / denominator;
            return new Complex(realpart, imagepart);
        }

        public static Complex operator -(Complex x)
        {
            return new Complex(-x.X, -x.Y);
        }

        public static Complex operator +(Complex x)
        {
            return new Complex(x.X, x.Y);
        }

        public override string ToString()
        {
            return $"{X} + {Y}i";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Complex))
            {
                return false;
            }
            Complex other = (Complex)obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();

                return hash;
            }
        }
    }
}
