using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface IRootFindingStrategy
    {
        Complex[] FindRoots(double[] coefficients);
    }

    public class LinearRootFindingStrategy : IRootFindingStrategy
    {
        public static readonly LinearRootFindingStrategy Instance = new LinearRootFindingStrategy();

        public Complex[] FindRoots(double[] coefficients)
        {
            if (coefficients.Length != 2)
                throw new ArgumentException("Linear equation requires 2 coefficients.");

            double a = coefficients[1];
            double b = coefficients[0];

            if (a == 0)
            {
                if (b == 0)
                    throw new ArgumentException("Infinite solutions for the equation.");
                else
                    throw new ArgumentException("No solutions for the equation.");
            }

            return new Complex[] { new Complex(-b / a) };
        }
    }

    public class QuadraticRootFindingStrategy : IRootFindingStrategy
    {
        public static readonly QuadraticRootFindingStrategy Instance = new QuadraticRootFindingStrategy();

        public Complex[] FindRoots(double[] coefficients)
        {
            if (coefficients.Length != 3)
                throw new ArgumentException("Quadratic equation requires 3 coefficients.");

            double a = coefficients[2];
            double b = coefficients[1];
            double c = coefficients[0];

            if (a == 0)
                return LinearRootFindingStrategy.Instance.FindRoots(new double[] { b, c });

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                return new Complex[]
                {
                new Complex((-b + sqrtDiscriminant) / (2 * a)),
                new Complex((-b - sqrtDiscriminant) / (2 * a))
                };
            }
            else if (discriminant == 0)
            {
                return new Complex[] { new Complex(-b / (2 * a)) };
            }
            else
            {
                Complex sqrtDiscriminant = new Complex(0, Math.Sqrt(-discriminant));
                return new Complex[]
                {
                new Complex(-b / (2 * a)),
                new Complex(-b / (2 * a))
                };
            }
        }
    }   

    public static class Strategies
    {
        public static IRootFindingStrategy SelectStrategy(double[] coefficients)
        {
            int dimension = coefficients.Length;
            if (dimension == 2)
                return LinearRootFindingStrategy.Instance;
            else if (dimension == 3)
                return QuadraticRootFindingStrategy.Instance;
            else
                throw new ArgumentException("Unknown equation type.");
        }
    }
}
