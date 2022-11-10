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

        public string fireNameWorker;
        public List<HourlyWageWorker> hourlyWorkers = new List<HourlyWageWorker>();
        public List<ComissionWageWorker> comissionWorkers = new List<ComissionWageWorker>();
        ObservableCollection<HourlyWageWorker> workers = new ObservableCollection<HourlyWageWorker>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddComissionWorker_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEquilName(comissionNameBox.Text) && NumberCheck(SalaryBox) && NumberCheck(percentBox) && CheckNullString(comissionNameBox.Text) && CheckNullString(ComissionGenderComboBox.Text))
            {
                comissionName = comissionNameBox.Text;
                comissionGender = ComissionGenderComboBox.Text;
                comissionSalary = Convert.ToInt32(SalaryBox.Text);
                comissionPercent = Convert.ToInt32(percentBox.Text);

                AddComissionWorker();

                comissionNameBox.Text = "";
                ComissionGenderComboBox.Text = "";
                SalaryBox.Text = "";
                percentBox.Text = "";
            }
        }

        private void btnAddHourlyWorker_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEquilName(hourlyNameBox.Text) && NumberCheck(normalSalaryBox) && NumberCheck(overtimeSalaryBox) && NumberCheck(standartHoursBox) && CheckNullString(hourlyNameBox.Text) && CheckNullString(HourlyGenderComboBox.Text))
            {
                hourlyName = hourlyNameBox.Text;
                hourlyGender = HourlyGenderComboBox.Text;
                normalHourlySalary = Convert.ToInt32(normalSalaryBox.Text);
                overtimeHourlySalary = Convert.ToInt32(overtimeSalaryBox.Text);
                standartOfHourlyWorkingHours = Convert.ToInt32(standartHoursBox.Text);

                AddHourlyWorker();

                hourlyNameBox.Text = "";
                HourlyGenderComboBox.Text = "";
                normalSalaryBox.Text = "";
                overtimeSalaryBox.Text = "";
                standartHoursBox.Text = "";
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

        private bool CheckEquilName(string name)
        {
            for (int index = 0; index < hourlyWorkers.Count; index++)
            {
                if (name == hourlyWorkers[index].fullName)
                {
                    MessageBox.Show("Нельзя вводить одинаковые имена");

                    return false;
                }
            }

            for (int index = 0; index < comissionWorkers.Count; index++)
            {
                if (name == comissionWorkers[index].fullName)
                {
                    MessageBox.Show("Нельзя вводить одинаковые имена");

                    return false;
                }
            }

            return true;
        }

        private void UpdateDataGridHourlyWorker()
        {
            if (hourlyWorkers.Count != 0)
            {
                foreach (var worker in hourlyWorkers)
                {
                    allWorkers.Items.Add(new { Name = hourlyWorkers[hourlyWorkers.Count - 1].fullName });
                }
            }
        }

        private void UpdateDataGridComissionWorker()
        {
            if (comissionWorkers.Count != 0)
            {
                foreach (var worker in comissionWorkers)
                {
                    allWorkers.Items.Add(new { Name = comissionWorkers[comissionWorkers.Count - 1].fullName });
                }
            }
        }

        private void btnFireWorker_Click(object sender, RoutedEventArgs e)
        {
            FireWorker();
        }

        private bool FireWorker()
        {
            fireNameWorker = fireNameBox.Text;

            foreach (var worker in hourlyWorkers)
            {
                if (worker.fullName == fireNameWorker)
                {
                    hourlyWorkers.Remove(worker);
                    fireNameBox.Text = "";
                    return true;
                }
            }

            foreach (var worker in comissionWorkers)
            {
                if (worker.fullName == fireNameWorker) 
                {
                    comissionWorkers.Remove(worker);
                    fireNameBox.Text = "";
                    return true;
                }
            }

            MessageBox.Show("Такого имени нет в списках работников");
            fireNameBox.Text = "";
            return false;
        }

        private void OutputWorkers(object sender, RoutedEventArgs e)
        {
            allWorkers.Items.Clear();
            UpdateDataGridHourlyWorker();
            UpdateDataGridComissionWorker();
        }

        private void SimulateWork()
        {
            int days = Convert.ToInt32(txtDays.Text);            
            var randomNumbers = new Random(Environment.TickCount);
            
            for (int workedDays = 0; workedDays < days; workedDays++)
            {
                foreach (var worker in hourlyWorkers)
                {
                    //Worker workerReferense = worker;

                    worker.Work(randomNumbers.Next() % MAX_PRICE);
                }

                workedDaysCount++;

                if (workedDaysCount % WORKING_CYCLE == 0)
                {
                    foreach (var worker in hourlyWorkers)
                        expenses += worker.CalculateWage();
                }
            }

            for (int workedDays = 0; workedDays < days; workedDays++)
            {
                foreach (var worker in comissionWorkers)
                {
                    //Worker workerReferense = worker;

                    worker.Work(randomNumbers.Next() % MAX_PRICE);
                }

                workedDaysCount++;

                if (workedDaysCount % WORKING_CYCLE == 0)
                {
                    foreach (var worker in comissionWorkers)
                        expenses += worker.CalculateWage();
                }
            }

            workedDaysCount %= 15;

            txtxBlockExpenses.Text = Convert.ToString(expenses);
            txtBlockWorkedDays.Text =Convert.ToString(workedDaysCount);


        }

   
        public int expenses = 0;
        private int workedDaysCount = 0;
        private const int MAX_PRICE = 15000;
        private const int WORKING_CYCLE = 15;

        private void btnSimulate_Click(object sender, RoutedEventArgs e)
        {
            SimulateWork();
        }
    }
}
