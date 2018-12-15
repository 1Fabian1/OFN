using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{
    class Polynomial
    {
        private string upFN1;
        private string upFN2;
        private string downFN1;
        private string downFN2;

        public Polynomial(string upFN1, string upFN2, string downFN1, string downFN2)
        {
            this.upFN1 = upFN1;
            this.upFN2 = upFN2;
            this.downFN1 = downFN1;
            this.downFN2 = downFN2;
        }

        public string UpFN1 { get => upFN1; set => upFN1 = value; }
        public string UpFN2 { get => upFN2; set => upFN2 = value; }
        public string DownFN1 { get => downFN1; set => downFN1 = value; }
        public string DownFN2 { get => downFN2; set => downFN2 = value; }


        private void Calculate(char znak)
        {

            //TO DO: Podaj stopien wielomianu, usunac StringBuilder, wyedytowac pole 
            StringBuilder builder = new StringBuilder("(" + upFN1 + ")" + znak + "(" + upFN2 +")");
            if (znak.Equals("+"))
            {

            }
        }
    }
}
