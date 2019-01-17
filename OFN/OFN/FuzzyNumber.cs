using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace OFN
{
    class FuzzyNumber
    {
        private String name;
        private double pos1;
        private double pos2;
        private double pos3;
        private double pos4;
        private List<double> up;
        private List<double> down;
        public FuzzyNumber()
        {
            this.pos1 = 0;
            this.pos2 = 0;
            this.pos3 = 0;
            this.pos4 = 0;
            this.Up = new List<double>();
            this.Down = new List<double>();
        }

        public FuzzyNumber(double pos1, double pos2, double pos3, double pos4, int discretizationParameter)
        {
            if (discretizationParameter == 0 || discretizationParameter.Equals(null) || discretizationParameter.Equals("")) discretizationParameter = 10;
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.pos3 = pos3;
            this.pos4 = pos4;
            up = CalculateUP(pos1, pos2, discretizationParameter);
            down = CalculateDown(pos3, pos4, discretizationParameter);
        }

        public FuzzyNumber(double pos1, double pos2, double pos3, double pos4)
        {
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.pos3 = pos3;
            this.pos4 = pos4;
        }

        public FuzzyNumber(double pos1, double pos2, double pos4)
        {
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.pos3 = pos2;
            this.pos4 = pos4;
        }

        public FuzzyNumber(double pos1, double pos2, double pos4, List<double> up, List<double> down)
        {
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.pos3 = pos2;
            this.pos4 = pos4;
            this.up = up;
            this.down = down;
        }
        public FuzzyNumber(double pos1, double pos2, double pos3, double pos4, int discretizationParameter, string name)
        {
            if (discretizationParameter == 0 || discretizationParameter.Equals(null) || discretizationParameter.Equals("")) discretizationParameter = 10;
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.pos3 = pos3;
            this.pos4 = pos4;
            up = CalculateUP(pos1, pos2, discretizationParameter);
            down = CalculateDown(pos3, pos4, discretizationParameter);
            this.name = name;
        }

        public double Pos1 { get => pos1; set => pos1 = value; }
        public double Pos2 { get => pos2; set => pos2 = value; }
        public double Pos3 { get => pos3; set => pos3 = value; }
        public double Pos4 { get => pos4; set => pos4 = value; }
        public List<double> Up { get => up; set => up = value; }
        public List<double> Down { get => down; set => down = value; }
        public string Name { get => name; set => name = value; }

        public FuzzyNumber GetFuzzyNumber()
        {
            FuzzyNumber fN = new FuzzyNumber();

            fN.pos1 = this.pos1;
            fN.pos2 = this.pos2;
            fN.pos3 = this.pos3;
            fN.pos4 = this.pos4;
            fN.up = this.Up;
            fN.down = this.down;
            fN.name = this.name;

            return fN;
        }

        public override string ToString()
        {
            return pos1.ToString("N2") + ", " + pos2.ToString("N2") + ", " + pos3.ToString("N2") + ", " + pos4.ToString("N2");
        }

        private List<double> CalculateUP(double pos1, double pos2, int discretizationParameter)
        {
            List<double> resultList = new List<double>();
            double putToList = 0;
            double jump = 1 / Double.Parse(discretizationParameter.ToString());
            double jumpTemp = jump;

            for (int i = 0; i < discretizationParameter; i++)
            {
                putToList = functionUp(pos1, pos2, jump);
                resultList.Add(putToList);
                jump += jumpTemp;

            }

            return resultList;
        }

        //to consider 
        private List<double> CalculateDown(double pos3, double pos4, int discretizationParameter)
        {
            List<double> resultList = new List<double>();
            double putToList = 0;
            double jump = 1 / Double.Parse(discretizationParameter.ToString());
            double jumpTemp = 1 - jump;
            int i = 0;

            for (; i < discretizationParameter; discretizationParameter--)
            {
                putToList = functionDown(pos3, pos4, jumpTemp);
                resultList.Add(putToList);
                jumpTemp -= jump;

            }

            return resultList;

        }

        private double functionUp(double pos1, double pos2, double jump)
        {
            double y, a, b = 0;
            a = pos2 - pos1;
            b = pos1;
            y = jump * a + b;

            return y;
        }

        private double functionDown(double pos3, double pos4, double jump)
        {
            double y, a, b = 0;
            a = pos4 - pos3;
            b = pos4;
            y = -jump * a + b;

            return y;
        }

        public int findMaxValueOfFuzzyNumber(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB, FuzzyNumber fuzzyNumberResult)
        {
            double maxVal = double.MinValue;
            int result;
            List<double> listOfValues = new List<double>();
            listOfValues.Add(fuzzyNumberA.pos1);
            listOfValues.Add(fuzzyNumberA.pos2);
            listOfValues.Add(fuzzyNumberA.pos3);
            listOfValues.Add(fuzzyNumberA.pos4);
            listOfValues.Add(fuzzyNumberB.pos1);
            listOfValues.Add(fuzzyNumberB.pos2);
            listOfValues.Add(fuzzyNumberB.pos3);
            listOfValues.Add(fuzzyNumberB.pos4);
            listOfValues.Add(fuzzyNumberResult.pos1);
            listOfValues.Add(fuzzyNumberResult.pos2);
            listOfValues.Add(fuzzyNumberResult.pos3);
            listOfValues.Add(fuzzyNumberResult.pos4);

            listOfValues.Sort();
            maxVal = listOfValues.Max();

            result = (int)maxVal;

            return result;
        }

        public static int findMaxValueOfFuzzyNumber(FuzzyNumber fuzzyNumber)
        {
            double maxVal = double.MinValue;
            int result;
            List<double> listOfValues = new List<double>();
            listOfValues.Add(fuzzyNumber.pos1);
            listOfValues.Add(fuzzyNumber.pos2);
            listOfValues.Add(fuzzyNumber.pos3);
            listOfValues.Add(fuzzyNumber.pos4);

            listOfValues.Sort();
            maxVal = listOfValues.Max();

            result = (int)maxVal;

            return result;
        }

        public bool detectFailureChange(FuzzyNumber fuzzyNumber)
        {
            bool detector = false;
            if (!sameSign(fuzzyNumber.Pos1, fuzzyNumber.pos2))
            {
                detector = true;
            }else if (!sameSign(fuzzyNumber.Pos2, fuzzyNumber.pos3))
            {
                detector = true;
            }else if (!sameSign(fuzzyNumber.Pos3, fuzzyNumber.pos4))
            {
                detector = true;
            }

            return detector;
        }

        private bool sameSign(double num1, double num2)
        {
            return num1 >= 0 && num2 >= 0 || num1 < 0 && num2 < 0;
        }


    }
}
