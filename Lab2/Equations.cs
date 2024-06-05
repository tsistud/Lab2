using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Equations
    {
        public static double[] RemoveExtraCoefficients(double[] coefficients)
        {
            int i = coefficients.Length - 1;
            while (i >= 0 && coefficients[i] == 0)
            {
                i--;
            }
            if (i == coefficients.Length - 1)
            {
                return coefficients;
            }
            else
            {
                double[] result = new double[i + 1];
                Array.Copy(coefficients, result, i + 1);
                return result;
            }
        }
    }
}
