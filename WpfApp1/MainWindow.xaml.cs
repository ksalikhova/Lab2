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
        public int normalSalary;
        public int overtimeSalary;
        public int standartOfWorkingHours;

        public string comissionName;
        public string comissionGender;
        public int salary;
        public int percent;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddComissionWorker_Click(object sender, RoutedEventArgs e)
        {
            comissionName = comissionNameBox.Text;
            comissionGender = ComissionGenderComboBox.Text;
            salary = NumberCheck(SalaryBox);
            percent = NumberCheck(percentBox);
        }

        private void btnAddHourlyWorker_Click(object sender, RoutedEventArgs e)
        {
            hourlyName = hourlyNameBox.Text;
            hourlyGender = HourlyGenderComboBox.Text;
            normalSalary = NumberCheck(normalSalaryBox);
            overtimeSalary = NumberCheck(overtimeSalaryBox);
            standartOfWorkingHours = NumberCheck(standartHoursBox);
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
    }
}
