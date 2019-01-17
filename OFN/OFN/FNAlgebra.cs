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
            fuzzy.Pos1 = fuzzyNumberA.Pos1 + fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 + fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 + fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 + fuzzyNumberB.Pos4;

            //adding UP part - //works 
            foreach (double x in fuzzyNumberA.Up)
            {
                var upHelper = x + fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upHelper);
                i++;
            }
            //adding DOWN part
            i = 0;
            foreach (double x in fuzzyNumberA.Down)
            {
                var downHelper = x + fuzzyNumberB.Down[i];
                fuzzy.Down.Add(downHelper);
                i++;
            }

            return fuzzy;
        }

        public static FuzzyNumber subtractAminusB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            int i = 0;
            fuzzy.Pos1 = fuzzyNumberA.Pos1 - fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 - fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 - fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 - fuzzyNumberB.Pos4;

            foreach (double x in fuzzyNumberA.Up)
            {
                var upHelper = x - fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upHelper);
                i++;
            }
            i = 0;
            foreach (double x in fuzzyNumberA.Down)
            {
                var downHelper = x - fuzzyNumberB.Down[i];
                fuzzy.Down.Add(downHelper);
                i++;
            }

            return fuzzy;
        }

        public static FuzzyNumber multiplyAB(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            int i = 0;
            fuzzy.Pos1 = fuzzyNumberA.Pos1 * fuzzyNumberB.Pos1;
            fuzzy.Pos2 = fuzzyNumberA.Pos2 * fuzzyNumberB.Pos2;
            fuzzy.Pos3 = fuzzyNumberA.Pos3 * fuzzyNumberB.Pos3;
            fuzzy.Pos4 = fuzzyNumberA.Pos4 * fuzzyNumberB.Pos4;
            foreach (double x in fuzzyNumberA.Up)
            {
                var upHelper = x * fuzzyNumberB.Up[i];
                fuzzy.Up.Add(upHelper);
                i++;
            }
            i = 0;
            foreach (double x in fuzzyNumberA.Down)
            {
                var downHelper = x * fuzzyNumberB.Down[i];
                fuzzy.Down.Add(downHelper);
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
            catch (Exception e)
            {
                Debug.WriteLine("Nie dziel przez 0");
                e.StackTrace.ToString();
            }

            return fuzzy;
        }

        //For now it may throw a null exception
        private static FuzzyNumber divideABpriv(FuzzyNumber fuzzyNumberA, FuzzyNumber fuzzyNumberB)
        {
            FuzzyNumber fuzzy = new FuzzyNumber();
            if (checkIfNotZero(fuzzyNumberA) && checkIfNotZero(fuzzyNumberB))
            {
                int i = 0;
                fuzzy.Pos1 = fuzzyNumberA.Pos1 / fuzzyNumberB.Pos1;
                fuzzy.Pos2 = fuzzyNumberA.Pos2 / fuzzyNumberB.Pos2;
                fuzzy.Pos3 = fuzzyNumberA.Pos3 / fuzzyNumberB.Pos3;
                fuzzy.Pos4 = fuzzyNumberA.Pos4 / fuzzyNumberB.Pos4;

                foreach (double x in fuzzyNumberA.Up)
                {
                    var upHelper = x / fuzzyNumberB.Up[i];
                    fuzzy.Up.Add(upHelper);
                    i++;
                }
                i = 0;
                foreach (double x in fuzzyNumberA.Down)
                {
                    var downHelper = x / fuzzyNumberB.Down[i];
                    fuzzy.Down.Add(downHelper);
                    i++;
                }

                return fuzzy;
            }
            else
            {
                return null;
            }

        }

        private static bool checkIfNotZero(FuzzyNumber fuzzyNumber)
        {
            if (Math.Abs(fuzzyNumber.Pos1) < 0.000001) return false;
            else if (Math.Abs(fuzzyNumber.Pos2) < 0.000001) return false;
            else if (Math.Abs(fuzzyNumber.Pos3) < 0.000001) return false;
            else if (Math.Abs(fuzzyNumber.Pos4) < 0.000001) return false;
            else return true;
        }
    }
}
