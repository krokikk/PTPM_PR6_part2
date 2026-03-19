using System;
using System.Collections.Generic;
using System.Globalization;
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
using PTPM_PR4;

namespace PTPM_PR4
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        double fx;
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click_Page1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click_Page3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string separator = CultureInfo.CurrentCulture
                .NumberFormat.NumberDecimalSeparator;

            string newText = textBox.Text.Remove(
                textBox.SelectionStart,
                textBox.SelectionLength);

            if (e.Text == separator && newText.Contains(separator))
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "-")
            {
                if (textBox.SelectionStart != 0 || newText.Contains("-"))
                {
                    e.Handled = true;
                }
                return;
            }

            if (!e.Text.All(char.IsDigit) && e.Text != separator)
            {
                e.Handled = true;
            }
        }
        private void FunCheck(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TBx.Text, out double x))
            {
                MessageBox.Show("Введите значения!");
                return;
            }
            var rb = (RadioButton)sender;

            if (rb1.IsChecked == true)
            {
                fx = MathFunctions.CalculateFx(x, 1);
            }
            else if (rb2.IsChecked == true)
            {
                fx = MathFunctions.CalculateFx(x, 2);
            }
            else if (rb3.IsChecked == true)
            {
                fx = MathFunctions.CalculateFx(x, 3);
            }

            if (rb1.IsChecked == false && rb2.IsChecked == false && rb3.IsChecked == false)
            {
                MessageBox.Show("Выберите функцию!");

            }
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {

            if (rb1.IsChecked == false && rb2.IsChecked == false && rb3.IsChecked == false)
            {
                MessageBox.Show("Выберите функцию!");
            } 

            if (string.IsNullOrEmpty(TBx.Text) || string.IsNullOrEmpty(TBi.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!double.TryParse(TBx.Text, out double x) ||
                !double.TryParse(TBi.Text, out double i))
            {
                MessageBox.Show("Введите корректные числа!");
                return;
            }

            double res = MathFunctions.CalculateResult(x, i, fx); res = MathFunctions.CalculateResult(x, i, fx);

            TBres.Text = Convert.ToString(Math.Round(res, 8));
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            TBx.Clear();
            TBi.Clear();
            TBres.Text = " ";
        }

    }
}
