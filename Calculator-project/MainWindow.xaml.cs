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

<<<<<<< HEAD
            switch (name)
=======
            // Check if the content is an operator
            if (IsOperator(content))
>>>>>>> gui
            {
                // If output is empty or the last character is not an operator, append the operator
                if (output.Length == 0 || !IsOperator(output[output.Length - 1].ToString()))
                {
                    output += content;
                    OutputTextBlock.Text = output;
<<<<<<< HEAD

                    break;

                case "TwoBtn":
                    output += "2";
                    OutputTextBlock.Text = output;

                    break;

                case "ThreeBtn":
                    output += "3";
                    OutputTextBlock.Text = output;

                    break;

                case "FourBtn":
                    output += "4";
                    OutputTextBlock.Text = output;

                    break;

                case "FiveBtn":
                    output += "5";
                    OutputTextBlock.Text = output;

                    break;

                case "SixBtn":
                    output += "6";
                    OutputTextBlock.Text = output;

                    break;

                case "SevenBtn":
                    output += "7";
                    OutputTextBlock.Text = output;

                    break;

                case "EightBtn":
                    output += "8";
                    OutputTextBlock.Text = output;

                    break;

                case "NineBtn":
                    output += "9";
                    OutputTextBlock.Text = output;

                    break;

                case "ZeroBtn":
                    output += "0";
                    OutputTextBlock.Text = output;

                    break;



            }

=======
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
>>>>>>> gui
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


<<<<<<< HEAD
                case "Product":
                    outputTemp = temp * double.Parse(output);
                    output = outputTemp.ToString();
                    OutputTextBlock.Text = output;
                    break;

                case "Divide":
                    if (double.Parse(output) != 0)
                    {
                        outputTemp = temp / double.Parse(output);
                        output = outputTemp.ToString();
                        OutputTextBlock.Text = output;
                    }
                    else
                    {
                        // Handle divide by zero error, for example:
                        OutputTextBlock.Text = "ERROR";
                    }
                    break;
=======
        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                output = "";
                OutputTextBlock.Text = output;
>>>>>>> gui
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

<<<<<<< HEAD



        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                double secondOperand = double.Parse(output);
                switch (operation)
                {
                    case "Plus":
                        output = (temp + secondOperand).ToString();
                        break;
                    case "Minus":
                        output = (temp - secondOperand).ToString();
                        break;
                    case "Product":
                        output = (temp * secondOperand).ToString();
                        break;
                    case "Divide":
                        if (secondOperand != 0) // Check for division by zero
                            output = (temp / secondOperand).ToString();
                        else
                            output = "Error"; // Handle division by zero error
                        break;
                }
                OutputTextBlock.Text = output;

            }
        }

=======
>>>>>>> gui
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
