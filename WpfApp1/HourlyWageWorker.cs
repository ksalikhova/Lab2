using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class HourlyWageWorker 
    {
        public string fullName { get; set; }
        public string gender { get; set; }
        public int normalSalary { get; set; }
        public int overtimeSalary { get; set; }
        public int standartOfWorkingHours { get; set; }

        public void Work(int hours)
        {
            hoursWorked += hours % 24;
            workedDays++;
        }

        public int CalculateWage()
        {
            var normalHoursWorked = (hoursWorked < standartOfWorkingHours * workedDays) ? hoursWorked : (standartOfWorkingHours * workedDays);
            var overtimeHoursWorked = hoursWorked - normalHoursWorked;

            hoursWorked = 0;
            workedDays = 0;

            return normalHoursWorked * normalSalary + overtimeHoursWorked * normalSalary;
        }


        private int hoursWorked;
        private int workedDays;
    }
}
