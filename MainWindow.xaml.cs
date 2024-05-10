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
        Operation operation;

        public MainWindow()
        {
            InitializeComponent();

            clearButton.Click += ClearButton_Click;
            negateButton.Click += NegateButton_Click;
            percentButton.Click += PercentButton_Click;
            pointButton.Click += PointButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
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
            if (double.TryParse(value, out double currentNumber))
            {
                result = lastNumber * currentNumber / 100.0;
                resultLabel.Content = result.ToString();
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            string value = resultLabel.Content.ToString()!;
            if (!value.Contains('.'))
            {
                resultLabel.Content = value + ".";
            }

        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(resultLabel.Content.ToString(), out double currentNumber))
            {
                switch (operation)
                {
                    case Operation.Add:
                        result = lastNumber + currentNumber;
                        break;
                    case Operation.Subtract:
                        result = lastNumber - currentNumber;
                        break;
                    case Operation.Multiply:
                        result = lastNumber * currentNumber;
                        break;
                    case Operation.Divide:
                        if (currentNumber != 0)
                        {
                            result = lastNumber / currentNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by 0", "DivideByZeroException", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            result = lastNumber;
                        }
                        break;
                    default: break;
                }
                resultLabel.Content = result.ToString();
            }

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            string value = resultLabel.Content.ToString()!;
            if (double.TryParse(value, out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender.Equals(addButton)) operation = Operation.Add;
            if (sender.Equals(subtractButton)) operation = Operation.Subtract;
            if (sender.Equals(multiplyButton)) operation = Operation.Multiply;
            if (sender.Equals(divideButton)) operation = Operation.Divide;

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string input = ((Button)sender).Content.ToString()!;

            if (resultLabel.Content.ToString()!.Equals("0"))
            {
                resultLabel.Content = input;
            }
            else
            {
                resultLabel.Content += input;
            }

        }

    }

    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}