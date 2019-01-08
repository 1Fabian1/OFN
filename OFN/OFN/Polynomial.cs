using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{
    class Polynomial
    {
        private double freeValue;
        private double valueX;
        private double valueX2;
        private double valueX3;
        private double valueX4;
        private double valueX5;
        private double valueX6;
        private double valueX7;
        private double valueX8;
        private double valueX9;
        private double valueX10;
        private string textPolynomial;

        public Polynomial()
        {
            this.freeValue = 0;
            this.valueX = 0;
            this.valueX2 = 0;
            this.valueX3 = 0;
            this.valueX4 = 0;
            this.valueX5 = 0;
            this.valueX6 = 0;
            this.valueX7 = 0;
            this.valueX8 = 0;
            this.valueX9 = 0;
            this.valueX10 = 0;
            this.textPolynomial = "";
        }

        public Polynomial(double freeValue, double valueX, double valueX2, double valueX3, double valueX4, double valueX5, double valueX6, double valueX7, double valueX8, double valueX9, double valueX10)
        {
            this.freeValue = freeValue;
            this.valueX = valueX;
            this.valueX2 = valueX2;
            this.valueX3 = valueX3;
            this.valueX4 = valueX4;
            this.valueX5 = valueX5;
            this.valueX6 = valueX6;
            this.valueX7 = valueX7;
            this.valueX8 = valueX8;
            this.valueX9 = valueX9;
            this.valueX10 = valueX10;
        }

        public double FreeValue { get => freeValue; set => freeValue = value; }
        public double ValueX { get => valueX; set => valueX = value; }
        public double ValueX2 { get => valueX2; set => valueX2 = value; }
        public double ValueX3 { get => valueX3; set => valueX3 = value; }
        public double ValueX4 { get => valueX4; set => valueX4 = value; }
        public double ValueX5 { get => valueX5; set => valueX5 = value; }
        public double ValueX6 { get => valueX6; set => valueX6 = value; }
        public double ValueX7 { get => valueX7; set => valueX7 = value; }
        public double ValueX8 { get => valueX8; set => valueX8 = value; }
        public double ValueX9 { get => valueX9; set => valueX9 = value; }
        public double ValueX10 { get => valueX10; set => valueX10 = value; }
        public string TextPolynomial { get => textPolynomial; set => textPolynomial = value; }

        public override string ToString()
        {
            String resultString = "";
            if (!valueX10.Equals(0)) resultString = resultString + valueX10.ToString() + "x\xB9" + "\x2070";
            if (valueX9 > 0) resultString = resultString + "+";
            if (!valueX9.Equals(0)) resultString = resultString + valueX9.ToString() + "x\x2079";
            if (valueX8 > 0) resultString = resultString + "+";
            if (!valueX8.Equals(0)) resultString = resultString + valueX8.ToString() + "x\x2078";
            if (valueX7 > 0) resultString = resultString + "+";
            if (!valueX7.Equals(0)) resultString = resultString + valueX7.ToString() + "x\x2077";
            if (valueX6 > 0) resultString = resultString + "+";
            if (!valueX6.Equals(0)) resultString = resultString + valueX6.ToString() + "x\x2076";
            if (valueX5 > 0) resultString = resultString + "+";
            if (!valueX5.Equals(0)) resultString = resultString + valueX5.ToString() + "x\x2075";
            if (valueX4 > 0) resultString = resultString + "+";
            if (!valueX4.Equals(0)) resultString = resultString + valueX4.ToString() + "x\x2074";
            if (valueX3 > 0) resultString = resultString + "+";
            if (!valueX3.Equals(0)) resultString = resultString + valueX3.ToString() + "x\xB3";
            if (valueX2 > 0) resultString = resultString + "+";
            if (!valueX2.Equals(0)) resultString = resultString + valueX2.ToString() + "x\xB2";
            if (valueX > 0) resultString = resultString + "+";
            if (!valueX.Equals(0)) resultString = resultString + valueX.ToString()   + "x";
            if (freeValue.Equals(0)) { }
            else if(freeValue > 0)
            {
                resultString = resultString + "+";
                resultString = resultString + freeValue.ToString();
            } else if(freeValue < 0) 
            {
                resultString = resultString + freeValue.ToString();
            }

            StringBuilder stringBuilder = new StringBuilder(resultString);
            if(stringBuilder.Length > 1)
            {
                if (stringBuilder[0].Equals('+'))
                {
                    stringBuilder.Remove(0, 1);
                }
                resultString = stringBuilder.ToString();
            }

            return resultString;
         
        }
    }

    
}
