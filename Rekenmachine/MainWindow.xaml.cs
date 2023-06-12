using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Rekenmachine
{
    public partial class MainWindow : Window
    {
        private List<string> inputList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();
            OutputTextBlock.Text += number;
            inputList.Add(number);
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();
            OutputTextBlock.Text += operation;
            inputList.Add(operation);
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            string expression = string.Join("", inputList);
            var dt = new DataTable();
            var result = dt.Compute(expression, "");
            OutputTextBlock.Text += $"= {result}";
            inputList.Clear();
            inputList.Add(result.ToString());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            inputList.Clear();
            OutputTextBlock.Text = string.Empty;
        }
    }
}