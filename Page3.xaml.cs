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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PTPM_PR4;

namespace PTPM_PR4
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            Chart.ChartAreas.Add(new ChartArea("Main"));

            var series = new Series("График функции")
            {
                ChartType = SeriesChartType.Line, 
                BorderWidth = 2
            };

            Chart.Series.Add(series);
        }

        private void Button_Click_Page2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBx.Text) || string.IsNullOrEmpty(TBxk.Text) || string.IsNullOrEmpty(TBdx.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!double.TryParse(TBx.Text.Replace(",", "."),
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out double x) ||

        !double.TryParse(TBxk.Text.Replace(",", "."),
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out double xk) ||

        !double.TryParse(TBdx.Text.Replace(",", "."),
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out double dx))
            {
                MessageBox.Show("Введите корректные числа!");
                return;
            }

            double b = 1;

            var series = Chart.Series[0];
            series.Points.Clear();

            string result = "";

            if (x > xk)
            {
                (x, xk) = (xk, x);
            }

            if (dx > (xk - x)) 
            {
                MessageBox.Show("Шаг не может быть больше интервала (x-xk)");
            }

            if (dx == 0)
            {
                MessageBox.Show("Шаг dx должен быть больше 0!");
                return;
            }

            for (double i = x; i <= xk; i += dx)
            {
                double y = Math.Pow(x, 4) + Math.Cos(2 + Math.Pow(x, 3) - b);

                series.Points.AddXY(x, y);

                result += $"x = {x:F3}    y = {y:F3}\n";

                x += dx;
            }

            TBres.Text = result;
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Chart.Series[0].Points.Clear();
            TBx.Clear();
            TBxk.Clear();
            TBdx.Clear();
            TBres.Text = "";
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
    }
}
