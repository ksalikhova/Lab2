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
        public string gender;
        public string normalSalary;
        public string overtimeSalary;
        public string standartOfWorkingHours;

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddHourlyWorker_Click(object sender, RoutedEventArgs e)
        {
            hourlyName = hourlyNameBox.Text;
            gender
            
        }
    }
}
