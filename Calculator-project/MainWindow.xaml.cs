using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator_project
{

    public partial class MainWindow : Window
    {
        double temp = 0;
        string operation = "";

        String output = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;


        }
        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string content = (string)((Button)sender).Content;

            // Check if the content is an operator
            if (IsOperator(content))
            {
                // If output is empty or the last character is not an operator, append the operator
                if (output.Length == 0 || !IsOperator(output[output.Length - 1].ToString()))
                {
                    output += content;
                    OutputTextBlock.Text = output;
                }
            }
            else
            {
                output += content;
                OutputTextBlock.Text = output;
            }
        }
        private bool IsOperator(string str)
        {
            return str == "+" || str == "-" || str == "*" || str == "/";
        }

        private string Calc()
        {
            return "the answer";
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                // Call Controller.Calc function to calculate the result
                //output = Controller.Calc(output);
                output = Calc();
                // Display the result
                OutputTextBlock.Text = output;
            }
        }


        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                output = "";
                OutputTextBlock.Text = output;
            }
        }



        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Minus";
            }
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Plus";
            }

        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Product";
            }
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Divide";
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
            temp = 0; // Reset temp
            operation = ""; // Reset operation
        }


        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the output already contains a decimal point
            if (!output.Contains(','))
            {
                output += ",";
                OutputTextBlock.Text = output;
            }
        }

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            output += Math.PI.ToString();
            OutputTextBlock.Text = output;
        }

        private void E_Btn_Click(object sender, RoutedEventArgs e)
        {
            output += Math.E.ToString();
            OutputTextBlock.Text = output;
        }



    }
}
