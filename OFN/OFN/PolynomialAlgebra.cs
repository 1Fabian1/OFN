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
            double[] polyA = new double[11];
            double[] polyB = new double[11];
            double [] results = new double[polyA.Length + polyB.Length];
            int polyASize = 0;
            int polyBSize = 0;

            polyA[0] = polynomialA.FreeValue;
            polyA[1] = polynomialA.ValueX;
            polyA[2] = polynomialA.ValueX2;
            polyA[3] = polynomialA.ValueX3;
            polyA[4] = polynomialA.ValueX4;
            polyA[5] = polynomialA.ValueX5;
            polyA[6] = polynomialA.ValueX6;
            polyA[7] = polynomialA.ValueX7;
            polyA[8] = polynomialA.ValueX8;
            polyA[9] = polynomialA.ValueX9;
            polyA[10] = polynomialA.ValueX10;

            polyB[0] = polynomialB.FreeValue;
            polyB[1] = polynomialB.ValueX;
            polyB[2] = polynomialB.ValueX2;
            polyB[3] = polynomialB.ValueX3;
            polyB[4] = polynomialB.ValueX4;
            polyB[5] = polynomialB.ValueX5;
            polyB[6] = polynomialB.ValueX6;
            polyB[7] = polynomialB.ValueX7;
            polyB[8] = polynomialB.ValueX8;
            polyB[9] = polynomialB.ValueX9;
            polyB[10] = polynomialB.ValueX10;

            foreach(var zm in polyA)
            {
                if (!zm.Equals(0))
                {
                    polyASize++;
                }
            }

            foreach (var zm in polyB)
            {
                if (!zm.Equals(0))
                {
                    polyBSize++;
                }
            }
            //polynomial.Test = polyASize.ToString() + " . " + polyBSize.ToString() ; 


            for (int i=0; i < polyASize; i++)
            {
                for(int j=0; j < polyBSize; j++)
                {
                    results[i + j] += polyA[i] * polyB[j];
                   /* if (!results[i + j].Equals(0))
                    {
                        polynomial.Test += results[i + j].ToString()+ " .";
                    }*/
                }

            }

            for(int i=0; i<polyASize+polyBSize-1; i++)
            {
                polynomial.Test += results[i].ToString();
                if(i != 0)
                {
                    polynomial.Test += "x^" + i.ToString();
                }
                if(i != polyASize + polyBSize - 1)
                {
                    polynomial.Test += " + ";
                }
            }

            

            return polynomial;
        }

        public static Polynomial dividePolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();


            return polynomial;
        }

    }
}
