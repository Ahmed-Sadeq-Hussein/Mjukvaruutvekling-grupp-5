using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator_project
{

    public partial class MainWindow : Window
    {

        String output = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;


        }
        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (string)((Button)sender).Content;

            if (IsOperator(buttonText))
            {  // Check if output is not empty and if the last character is not an operator

                if (output != "" && !IsOperator(output[output.Length - 1].ToString()))
                {
                    output += buttonText; // Append the new operator
                    OutputTextBlock.Text = output;
                }
            }
            else
            {
                output += buttonText;
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
                output = Calc(output);
                // Display the result
                OutputTextBlock.Text = output;


            }
        }


        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }



        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;

        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;

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
