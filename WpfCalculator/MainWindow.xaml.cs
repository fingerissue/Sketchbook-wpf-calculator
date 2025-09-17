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
                ResultTextBlock.Text = number;
                isNewEntry = false;
            }
            else
            {
                ResultTextBlock.Text += number;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            operand1 = double.Parse(ResultTextBlock.Text);
            op = clickedButton.Content.ToString();
            isNewEntry = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
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
                        MessageBox.Show("0으로 나눌 수 없습니다", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    result = operand1 / operand2;
                    break;
            }

            ResultTextBlock.Text = result.ToString();
            isNewEntry = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "0";
        }
    }
}