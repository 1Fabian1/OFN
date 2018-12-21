using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{

    //TODO: Multiply and Substract Methods

    class PolynomialAlgebra
    {
        public static Polynomial addPolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();

            polynomial.FreeValue = polynomialA.FreeValue + polynomialB.FreeValue;
            polynomial.ValueX = polynomialA.ValueX + polynomialB.ValueX;
            polynomial.ValueX2 = polynomialA.ValueX2 + polynomialB.ValueX2;
            polynomial.ValueX3 = polynomialA.ValueX3 + polynomialB.ValueX3;
            polynomial.ValueX4 = polynomialA.ValueX4 + polynomialB.ValueX4;
            polynomial.ValueX5 = polynomialA.ValueX5 + polynomialB.ValueX5;
            polynomial.ValueX6 = polynomialA.ValueX6 + polynomialB.ValueX6;
            polynomial.ValueX7 = polynomialA.ValueX7 + polynomialB.ValueX7;
            polynomial.ValueX8 = polynomialA.ValueX8 + polynomialB.ValueX8;
            polynomial.ValueX9 = polynomialA.ValueX9 + polynomialB.ValueX9;
            polynomial.ValueX10 = polynomialA.ValueX10 + polynomialB.ValueX10;

            return polynomial;
            
        }

        public static Polynomial substractPolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();

            polynomial.FreeValue = polynomialA.FreeValue - polynomialB.FreeValue;
            polynomial.ValueX = polynomialA.ValueX - polynomialB.ValueX;
            polynomial.ValueX2 = polynomialA.ValueX2 - polynomialB.ValueX2;
            polynomial.ValueX3 = polynomialA.ValueX3 - polynomialB.ValueX3;
            polynomial.ValueX4 = polynomialA.ValueX4 - polynomialB.ValueX4;
            polynomial.ValueX5 = polynomialA.ValueX5 - polynomialB.ValueX5;
            polynomial.ValueX6 = polynomialA.ValueX6 - polynomialB.ValueX6;
            polynomial.ValueX7 = polynomialA.ValueX7 - polynomialB.ValueX7;
            polynomial.ValueX8 = polynomialA.ValueX8 - polynomialB.ValueX8;
            polynomial.ValueX9 = polynomialA.ValueX9 - polynomialB.ValueX9;
            polynomial.ValueX10 = polynomialA.ValueX10 - polynomialB.ValueX10;

            return polynomial;

        }

        public static Polynomial multiplyPolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();


            return polynomial;
        }

        public static Polynomial dividePolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();


            return polynomial;
        }

    }
}
