using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<HourlyWageWorker> workers = new ObservableCollection<HourlyWageWorker>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddComissionWorker_Click(object sender, RoutedEventArgs e)
        {
            if (CheckComissionEquilName() && NumberCheck(SalaryBox) && NumberCheck(percentBox) && CheckNullString(comissionNameBox.Text) && CheckNullString(ComissionGenderComboBox.Text))
            {
                comissionName = comissionNameBox.Text;
                comissionGender = ComissionGenderComboBox.Text;
                comissionSalary = Convert.ToInt32(SalaryBox.Text);
                comissionPercent = Convert.ToInt32(percentBox.Text);

                AddComissionWorker();
            }
        }

        private void btnAddHourlyWorker_Click(object sender, RoutedEventArgs e)
        {
            if (CheckHourlyEquilName() && NumberCheck(normalSalaryBox) && NumberCheck(overtimeSalaryBox) && NumberCheck(standartHoursBox) && CheckNullString(hourlyNameBox.Text) && CheckNullString(HourlyGenderComboBox.Text))
            {
                hourlyName = hourlyNameBox.Text;
                hourlyGender = HourlyGenderComboBox.Text;
                normalHourlySalary = Convert.ToInt32(normalSalaryBox.Text);
                overtimeHourlySalary = Convert.ToInt32(overtimeSalaryBox.Text);
                standartOfHourlyWorkingHours = Convert.ToInt32(standartHoursBox.Text);

                AddHourlyWorker();
            }
        }

        private bool NumberCheck(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text)) 
            {
                MessageBox.Show("Неправильный ввод");
                return false;
            }

            foreach (var symbol in textBox.Text)
            {
                if (!char.IsDigit(symbol))
                {
                    MessageBox.Show("Неправильный ввод");
                    return false;
                }
            }

            if (Convert.ToInt32(textBox.Text) != 0) return true;

            MessageBox.Show("Неправильный ввод");
            return false;
        }

        private bool CheckNullString(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                MessageBox.Show("Строка не может быть пустой");
                return false;
            }

            return true;
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

            allWorkers.Items.Add(new { Name = hourlyWorkers[hourlyWorkers.Count -1 ].fullName } );
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

            allWorkers.Items.Add(new {Name = comissionWorkers[comissionWorkers.Count -1].fullName } );
        }

        private bool CheckHourlyEquilName()
        {
            for (int index = 0; index < hourlyWorkers.Count; index++)
            {
                if (hourlyName == hourlyWorkers[index].fullName)
                {
                    MessageBox.Show("Нельзя вводить одинаковые имена");

                    return false;
                }
            }
            return true;
        }

        private bool CheckComissionEquilName()
        {
            for (int index = 0; index < comissionWorkers.Count; index++)
            {
                if (comissionName == comissionWorkers[index].fullName)
                {
                    MessageBox.Show("Нельзя вводить одинаковые имена");

                    return false;
                }
            }

            return true;
        }
    }
}
