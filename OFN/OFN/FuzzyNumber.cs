using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{
    class FuzzyNumber
    {
        private double pos1;
        private double pos2;
        private double pos3;
        private double pos4;

        public FuzzyNumber()
        {
            this.pos1 = 0;
            this.pos2 = 0;
            this.pos3 = 0;
            this.pos4 = 0;
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

        public double Pos1 { get => pos1; set => pos1 = value; }
        public double Pos2 { get => pos2; set => pos2 = value; }
        public double Pos3 { get => pos3; set => pos3 = value; }
        public double Pos4 { get => pos4; set => pos4 = value; }

        public override string ToString()
        {
            return pos1.ToString() + ", " + pos2.ToString() + ", " + pos3.ToString() + ", " + pos4.ToString();
        }

        //public double myParser(string )


    }
}
