using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        private double operand1 = 0;
        private string op = "";
        private bool isNewEntry = false;

        public MainWindow()
        {
            InitializeComponent();
        
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string number = clickedButton.Content.ToString();
            
            if (isNewEntry || ResultTextBlock.Text == "0")
            {
                if (number == ".")
                {
                    ResultTextBlock.Text = "0.";
                }
                else
                {
                    ResultTextBlock.Text = number;
                }
                isNewEntry = false;
            }
            else
            {
                if (number == "." && ResultTextBlock.Text.Contains("."))
                {
                    return;
                }
                ResultTextBlock.Text += number;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(op) && !isNewEntry)
            {
                PerformCalculation();
            }
            else
            {
                operand1 = double.Parse(ResultTextBlock.Text);
            }
            
            Button clickedButton = sender as Button;
            op = clickedButton.Content.ToString();
            EquationTextBlock.Text = $"{operand1} {op}";
            isNewEntry = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(op))
            {
                PerformCalculation();
                EquationTextBlock.Text = "";
                op = "";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "0";
            EquationTextBlock.Text = "";
            operand1 = 0;
            op = "";
            isNewEntry = false;
        }

        private void PerformCalculation()
        {
            double operand2 = double.Parse(ResultTextBlock.Text);
            double result = 0;

            switch (op)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    result = operand1 / operand2;
                    break;
            }

            ResultTextBlock.Text = result.ToString();
            operand1 = result;
        }
    }
}