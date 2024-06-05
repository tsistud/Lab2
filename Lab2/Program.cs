using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double[] coefficients;
                while (true)
                {
                    Console.WriteLine("Enter the coefficients of the polynomial equation separated by spaces:");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(' ');
                    coefficients = new double[parts.Length];
                    bool success = true;
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (!double.TryParse(parts[i], out coefficients[i]))
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success)
                        break;
                    else
                        Console.WriteLine("Invalid input. Please enter valid coefficients.");
                }

                PolynomialEquation equation = new PolynomialEquation(coefficients);
                Complex[] roots = equation.FindRoots();
                Console.WriteLine("Roots of the equation:");
                foreach (Complex root in roots)
                {
                    Console.WriteLine(root);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
