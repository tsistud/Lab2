using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface IPolynomialEquation
    {
        int Dimension { get; }
        double[] Coefficients { get; }
        Complex[] FindRoots();
    }

    public class PolynomialEquation : IPolynomialEquation
    {
        private readonly double[] _coefficients;
        private readonly IRootFindingStrategy _strategy;

        public PolynomialEquation(double[] coefficients)
        {
            _coefficients = coefficients;
            _coefficients = Equations.RemoveExtraCoefficients(_coefficients);
            _strategy = Strategies.SelectStrategy(_coefficients);
        }

        public int Dimension => _coefficients.Length;

        public double[] Coefficients => (double[])_coefficients.Clone();

        public Complex[] FindRoots()
        {
            return _strategy.FindRoots(_coefficients);
        }
    }
}
