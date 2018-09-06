using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public Complex GetConjugate()
        {
            return new Complex(Re, -Im);
        }

        public double Abs()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }

        #region Operators
        public static Complex operator+(Complex first, Complex second)
        {
            return new Complex(first.Re + second.Re, first.Im + second.Im);
        }

        public static Complex operator-(Complex first, Complex second)
        {
            return new Complex(first.Re - second.Re, first.Im - second.Im);
        }

        public static Complex operator*(Complex first, Complex second)
        {
            return new Complex(first.Re * second.Re - first.Im * second.Im, first.Re * second.Im + first.Im * second.Re);
        }

        public static Complex operator/(Complex first, Complex second)
        {
            Complex numerator = first * second.GetConjugate();
            Complex denominator = second * second.GetConjugate();
            return new Complex(numerator.Re / denominator.Re, numerator.Im / denominator.Im);
        }
        #endregion

        public delegate Complex del(Complex z, Complex c);
        public static del MandelBrot = (z, c) => z * z + c;

        public bool IsConvergent()
        {
            int iters = 0;
            Complex current = new Complex(0, 0);
            while (iters < 100 && current.Abs() < 2)
            {
                current = MandelBrot(current, this);
                iters++;
            }
            return iters == 100;
        }
    }
}
