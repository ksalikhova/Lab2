using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ComissionWageWorker 
    {
        public string fullName { get; set; }
        public string gender { get; set; }
        public int salary { get; set; }
        public int percentage { get; set; }

      
        public void Work(int goodsSold)
        {
            goodsSoldSum += goodsSold % MAX_PRICE;
        }

        public int CalculateWage()
        {
            var wage = 0;
            var addition = (int)((float)goodsSoldSum * (float)percentage / 100);

            if (addition != 0)
                wage = salary + addition;

            goodsSoldSum = 0;

            return wage;
        }

        private static int goodsSoldSum;
        private const int MAX_PRICE = 15000;
    }
}
