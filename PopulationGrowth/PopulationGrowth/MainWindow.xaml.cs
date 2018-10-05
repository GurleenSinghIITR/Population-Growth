using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PopulationGrowth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vm vm = new Vm();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            vm.Shew();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            vm.Shoot();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            vm.Resets();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.Saves();
        }

        private void InPopulation_PreviewTextInput(object sender, TextCompositionEventArgs e)   /// Validations for the input to be a number
        {
            bool isInputTextNumber = new Regex("[0-9]").IsMatch(e.Text);
            e.Handled = !isInputTextNumber;
        }

        private void PopulationIncreaseRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex("[0-9]").IsMatch(e.Text);
            e.Handled = !isInputTextNumber;
        }

        private void DaysToCalculate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex("[0-9]").IsMatch(e.Text);
            e.Handled = !isInputTextNumber;
        }

        private void MortalityRatePerDay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex("[0-9]").IsMatch(e.Text);
            e.Handled = !isInputTextNumber;
        }
    }
}
