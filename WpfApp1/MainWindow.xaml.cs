using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string hourlyName;
        public string hourlyGender;
        public int normalHourlySalary;
        public int overtimeHourlySalary;
        public int standartOfHourlyWorkingHours;

        public string comissionName;
        public string comissionGender;
        public int comissionSalary;
        public int comissionPercent;

        public List<HourlyWageWorker> hourlyWorkers = new List<HourlyWageWorker>();
        public List<ComissionWageWorker> comissionWorkers = new List<ComissionWageWorker>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddComissionWorker_Click(object sender, RoutedEventArgs e)
        {
            comissionName = comissionNameBox.Text;
            comissionGender = ComissionGenderComboBox.Text;
            comissionSalary = NumberCheck(SalaryBox);
            comissionPercent = NumberCheck(percentBox);

            AddComissionWorker();
        }

        private void btnAddHourlyWorker_Click(object sender, RoutedEventArgs e)
        {
            hourlyName = hourlyNameBox.Text;
            hourlyGender = HourlyGenderComboBox.Text;
            normalHourlySalary = NumberCheck(normalSalaryBox);
            overtimeHourlySalary = NumberCheck(overtimeSalaryBox);
            standartOfHourlyWorkingHours = NumberCheck(standartHoursBox);

            AddHourlyWorker();
        }

        private int NumberCheck(TextBox textBox)
        {
            foreach (var symbol in textBox.Text)
            {
                if (!char.IsDigit(symbol))
                {
                    MessageBox.Show("Неправильный ввод");
                    return 1;
                }
            }

            if (Convert.ToInt32(textBox.Text) != 0) return Convert.ToInt32(textBox.Text);

            MessageBox.Show("Неправильный ввод");
            return 1;
        }

        private void AddHourlyWorker()
        {
            hourlyWorkers.Add(
                new HourlyWageWorker()
                {
                    fullName = hourlyName,
                    gender = hourlyGender,
                    normalSalary = normalHourlySalary,
                    overtimeSalary = overtimeHourlySalary,
                    standartOfWorkingHours=standartOfHourlyWorkingHours
                }) ;

            
        }

        private void AddComissionWorker()
        {
            comissionWorkers.Add(
                new ComissionWageWorker()
                {
                    fullName = comissionName,
                    gender = comissionGender,
                    salary = comissionSalary,
                    percentage =comissionPercent
                });
        }
    }
}
