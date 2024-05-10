using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;

        public MainWindow()
        {
            InitializeComponent();

            equalsButton.Click += EqualsButton_Click;
            clearButton.Click += ClearButton_Click;
            negateButton.Click += NegateButton_Click;
            percentButton.Click += PercentButton_Click;

        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            string value = resultLabel.Content.ToString()!;
            if (double.TryParse(value, out lastNumber) && lastNumber != 0)
            {
                result = lastNumber * -1.0;
                resultLabel.Content = result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            string value = resultLabel.Content.ToString()!;
            if (double.TryParse(value, out lastNumber) && lastNumber != 0)
            {
                result = lastNumber / 100.0;
                resultLabel.Content = result.ToString();
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string input;

            if (sender.Equals(zeroButton)) input = "0";
            else if (sender.Equals(oneButton)) input = "1";
            else if (sender.Equals(twoButton)) input = "2";
            else if (sender.Equals(threeButton)) input = "3";
            else if (sender.Equals(fourButton)) input = "4";
            else if (sender.Equals(fiveButton)) input = "5";
            else if (sender.Equals(sixButton)) input = "6";
            else if (sender.Equals(sevenButton)) input = "7";
            else if (sender.Equals(eightButton)) input = "8";
            else if (sender.Equals(nineButton)) input = "9";
            else return;

            if (resultLabel.Content.ToString()!.Equals("0"))
            {
                resultLabel.Content = input;
            }
            else {
                resultLabel.Content += input;
            }
        }

    }
}