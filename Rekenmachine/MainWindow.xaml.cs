using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Rekenmachine
{
    // The main window of a calculator application
    public partial class MainWindow : Window
    {
        // A list to store the user's input
        private List<string> inputList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for number buttons
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the clicked number from the button
            Button button = (Button)sender;
            string number = button.Content.ToString();

            // Append the number to the output text block
            OutputTextBlock.Text += number;

            // Store the number in the input list
            inputList.Add(number);
        }

        // Event handler for operator buttons
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the clicked operator from the button
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            // Append the operator to the output text block
            OutputTextBlock.Text += operation;

            // Store the operator in the input list
            inputList.Add(operation);
        }

        // Event handler for the equals button
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            // Join the elements of the input list into a string expression
            string expression = string.Join("", inputList);

            try
            {
                // Use a DataTable to compute the expression
                var dt = new DataTable();
                var result = dt.Compute(expression, "");

                // Append the result to the output text block
                OutputTextBlock.Text += $"= {result}";

                // Clear the input list and store the result as the new input
                inputList.Clear();
                inputList.Add(result.ToString());
            }
            catch (Exception ex)
            {
                // Display an error message to the user
                OutputTextBlock.Text = $"Error: {ex.Message}";

                // Clear the input list
                inputList.Clear();
            }
        }

        // Event handler for the clear button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the input list and reset the output text block
            inputList.Clear();
            OutputTextBlock.Text = string.Empty;
        }
    }
}
