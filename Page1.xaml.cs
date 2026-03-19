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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click_Page2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
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

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBx.Text) || string.IsNullOrEmpty(TBy.Text) || string.IsNullOrEmpty(TBz.Text)){
                MessageBox.Show("Заполните все поля.");
                return;
            }
            if (!double.TryParse(TBx.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double x) ||
                !double.TryParse(TBy.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double y) ||
                !double.TryParse(TBz.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double z))
            {
                MessageBox.Show("Введите корректные числа.");
                return;
            }

            double res = MathFunctions.CalculateExpression(x, y, z);

            TBres.Text = Convert.ToString(res);
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            TBx.Clear();
            TBy.Clear();
            TBz.Clear();
            TBres.Text = " ";
        }
    }
}
