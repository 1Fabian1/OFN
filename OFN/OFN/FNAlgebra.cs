using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{
    class FNAlgebra
    {
        FuzzyNumber fuzzyNumber = new FuzzyNumber();

        public static FuzzyNumber addAplusB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            int i = 0;
            double upAddHelper = 0;
            fuzzy.Pos1 = fuzzyNumberA.Pos1 + fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 + fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 + fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 + fuzzyNumberB.Pos4;

            //adding UP part - //works 
            foreach (double x in fuzzyNumberA.Up)
            {
                upAddHelper = x + fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }

            foreach (double x in fuzzyNumberA.Down)
            {
                upAddHelper = x + fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }

            return fuzzy;
        }

        public static FuzzyNumber subtractAminusB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            int i = 0;
            double upAddHelper = 0;
            fuzzy.Pos1 = fuzzyNumberA.Pos1 - fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 - fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 - fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 - fuzzyNumberB.Pos4;

            foreach (double x in fuzzyNumberA.Up)
            {
                upAddHelper = x - fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }
            foreach (double x in fuzzyNumberA.Down)
            {
                upAddHelper = x + fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }

            return fuzzy;
        }

        public static FuzzyNumber multiplyAB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            int i = 0;
            double upAddHelper = 0;
            fuzzy.Pos1 = fuzzyNumberA.Pos1 * fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 * fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 * fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 * fuzzyNumberB.Pos4;
            foreach (double x in fuzzyNumberA.Up)
            {
                upAddHelper = x * fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }
            foreach (double x in fuzzyNumberA.Down)
            {
                upAddHelper = x + fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upAddHelper);
                i++;
            }

            return fuzzy;
        }

        public static FuzzyNumber divideAB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            try
            {
                fuzzy = divideABpriv(fuzzyNumberA, fuzzyNumberB);
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("Nie dziel przez 0");
                e.StackTrace.ToString();
            }

            return fuzzy;
        }

        //For now it may throw an null exception
        private static FuzzyNumber divideABpriv(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            if (checkIfNotZero(fuzzyNumberA) && checkIfNotZero(fuzzyNumberB))
            {
                int i = 0;
                double upAddHelper = 0;
                fuzzy.Pos1 = fuzzyNumberA.Pos1 / fuzzyNumberB.Pos1;
                fuzzy.Pos2 = fuzzyNumberA.Pos2 / fuzzyNumberB.Pos2;
                fuzzy.Pos3 = fuzzyNumberA.Pos3 / fuzzyNumberB.Pos3;
                fuzzy.Pos4 = fuzzyNumberA.Pos4 / fuzzyNumberB.Pos4;

                foreach (double x in fuzzyNumberA.Up)
                {
                    upAddHelper = x / fuzzyNumberB.Up[i];
                    fuzzy.Up.Add(upAddHelper);
                    i++;
                }
                foreach (double x in fuzzyNumberA.Down)
                {
                    upAddHelper = x + fuzzyNumberB.Up[i];
                    fuzzy.Up.Add(upAddHelper);
                    i++;
                }

                return fuzzy;
            }
            return null;

        }

        private static Boolean checkIfNotZero(FuzzyNumber fuzzyNumber)
        {
            if (fuzzyNumber.Pos1 == 0) return false;
            else if (fuzzyNumber.Pos2 == 0) return false;
            else if (fuzzyNumber.Pos3 == 0) return false;
            else if (fuzzyNumber.Pos4 == 0) return false;
            else return true;
        }
    }
}
