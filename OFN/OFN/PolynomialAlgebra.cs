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

            for (int i=0; i < polyA.Length; i++)
            {
                for(int j=0; j < polyB.Length; j++)
                {
                    results[i + j] += polyA[i] * polyB[j];
                }

            }
            
            for(int i=results.Length - 1; i>=0; i--)
            {
                if (i != results.Length - 1 && results[i] != 0 && i != results.Length - 1)
                {
                    if (results[i] > 0)
                    {

                        polynomial.TextPolynomial += "+";

                    }
                }

                if (results[i] != 0)
                {
                    switch (i)
                    {
                        case 1:
                            polynomial.TextPolynomial += results[i].ToString() + "x";
                            break;
                        case 2:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB2";
                            break;
                        case 3:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB3";
                            break;
                        case 4:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2074";
                            break;
                        case 5:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2075";
                            break;
                        case 6:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2076";
                            break;
                        case 7:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2077";
                            break;
                        case 8:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2078";
                            break;
                        case 9:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2079";
                            break;
                        case 10:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2070";
                            break;
                        case 11:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB9";
                            break;
                        case 12:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB2";
                            break;
                        case 13:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB3";
                            break;
                        case 14:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2074";
                            break;
                        case 15:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2075";
                            break;
                        case 16:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2076";
                            break;
                        case 17:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2077";
                            break;
                        case 18:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2078";
                            break;
                        case 19:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2079";
                            break;
                        case 20:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB2" + "\x2070";
                            break;
                        default:
                            polynomial.TextPolynomial += results[i].ToString() + " ";
                            break;

                    }
                }

            }

            StringBuilder stringBuilder = new StringBuilder(polynomial.TextPolynomial);
            if (stringBuilder.Length > 1)
            {
                if (stringBuilder[0].Equals('+'))
                {
                    stringBuilder.Remove(0, 1);
                }
                polynomial.TextPolynomial = stringBuilder.ToString();
            }


            return polynomial;
        }
        
        public static Polynomial dividePolynomialAB(Polynomial polynomialA, Polynomial polynomialB)
        {
            Polynomial polynomial = new Polynomial();
            double[] polyA = new double[11];
            double[] polyB = new double[11];
            double[] results = new double[polyA.Length + polyB.Length];

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






            for (int i = results.Length - 1; i >= 0; i--)
            {
                if (i != results.Length - 1 && results[i] != 0 && i != results.Length - 1)
                {
                    if (results[i] > 0)
                    {

                        polynomial.TextPolynomial += "+";

                    }
                }

                if (results[i] != 0)
                {
                    switch (i)
                    {
                        case 1:
                            polynomial.TextPolynomial += results[i].ToString() + "x";
                            break;
                        case 2:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB2";
                            break;
                        case 3:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB3";
                            break;
                        case 4:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2074";
                            break;
                        case 5:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2075";
                            break;
                        case 6:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2076";
                            break;
                        case 7:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2077";
                            break;
                        case 8:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2078";
                            break;
                        case 9:
                            polynomial.TextPolynomial += results[i].ToString() + "x\x2079";
                            break;
                        case 10:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2070";
                            break;
                        case 11:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB9";
                            break;
                        case 12:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB2";
                            break;
                        case 13:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\xB3";
                            break;
                        case 14:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2074";
                            break;
                        case 15:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2075";
                            break;
                        case 16:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2076";
                            break;
                        case 17:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2077";
                            break;
                        case 18:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2078";
                            break;
                        case 19:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB9" + "\x2079";
                            break;
                        case 20:
                            polynomial.TextPolynomial += results[i].ToString() + "x\xB2" + "\x2070";
                            break;
                        default:
                            polynomial.TextPolynomial += results[i].ToString() + " ";
                            break;

                    }
                }

            }

            StringBuilder stringBuilder = new StringBuilder(polynomial.TextPolynomial);
            if (stringBuilder.Length > 1)
            {
                if (stringBuilder[0].Equals('+'))
                {
                    stringBuilder.Remove(0, 1);
                }
                polynomial.TextPolynomial = stringBuilder.ToString();
            }


            return polynomial;
        }


    }
}
