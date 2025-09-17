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

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            double currentValue = double.Parse(ResultTextBlock.Text);

            if (currentValue != 0)
            {
                currentValue *= -1;
                ResultTextBlock.Text = currentValue.ToString();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    NumberButton_Click(Button0, null);
                    break;
                case Key.D1:
                case Key.NumPad1:
                    NumberButton_Click(Button1, null);
                    break;
                case Key.D2:
                case Key.NumPad2:
                    NumberButton_Click(Button2, null);
                    break;
                case Key.D3:
                case Key.NumPad3:
                    NumberButton_Click(Button3, null);
                    break;
                case Key.D4:
                case Key.NumPad4:
                    NumberButton_Click(Button4, null);
                    break;
                case Key.D5:
                case Key.NumPad5:
                    NumberButton_Click(Button5, null);
                    break;
                case Key.D6:
                case Key.NumPad6:
                    NumberButton_Click(Button6, null);
                    break;
                case Key.D7:
                case Key.NumPad7:
                    NumberButton_Click(Button7, null);
                    break;
                case Key.D8:
                case Key.NumPad8:
                    NumberButton_Click(Button8, null);
                    break;
                case Key.D9:
                case Key.NumPad9:
                    NumberButton_Click(Button9, null);
                    break;
                case Key.OemPeriod:
                case Key.Decimal:
                    NumberButton_Click(ButtonDemical, null);
                    break;

                case Key.Add:
                    OperatorButton_Click(ButtonAdd, null);
                    break;
                case Key.Subtract:
                    OperatorButton_Click(ButtonSubtract, null);
                    break;
                case Key.Multiply:
                    OperatorButton_Click(ButtonMultiply, null);
                    break;
                case Key.Divide:
                    OperatorButton_Click(ButtonDivide, null);
                    break;

                case Key.Enter:
                    EqualsButton_Click(ButtonEquals, null);
                    break;

                case Key.Escape:
                case Key.Back:
                    ClearButton_Click(ButtonClear, null);
                    break;
            }
        }
    }
}