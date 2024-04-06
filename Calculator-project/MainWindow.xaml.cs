using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator_project
{

    public partial class MainWindow : Window
    {
        Controller.Controller controller = new Controller.Controller();

        string output = "0";
        bool currentNumIncludesDecimal = false;
        bool zeroIsAvailable = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;

            if (buttonContent == "0") // If the zero button is pressed, check to see if a zeroAvailable is true before adding
            {
                if (zeroIsAvailable)
                {
                    if (EndsWithOperator(output))
                    {
                        zeroIsAvailable = false;
                    }
                    output += buttonContent;
                    OutputTextBlock.Text = output;
                }
            }
            else // If any other number button is pressed, add it
            {
                if (output == "0")
                {
                    output = buttonContent;
                }
                else
                {
                    output += buttonContent;
                }
                OutputTextBlock.Text = output;

            }
        }

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            zeroIsAvailable = false;
            currentNumIncludesDecimal = true;
            output += Math.PI.ToString();
            OutputTextBlock.Text = output;
        }

        private void E_Btn_Click(object sender, RoutedEventArgs e)
        {
            zeroIsAvailable = false;
            currentNumIncludesDecimal = true;
            output += Math.E.ToString();
            OutputTextBlock.Text = output;
        }

        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the output already contains a decimal point
            if (!currentNumIncludesDecimal)
            {
                if (EndsWithOperator(output))
                {
                    output += "0.";
                }
                else
                {
                    output += '.';
                }
                zeroIsAvailable = true;
                OutputTextBlock.Text = output;
                currentNumIncludesDecimal = true;
            }
        }

        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;
            if (!EndsWithOperator(output)) // If the expression does NOT end with an operator, add the pressed operator
            {
                zeroIsAvailable = true;
                currentNumIncludesDecimal = false;
                output += buttonContent;
                OutputTextBlock.Text = output;
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "0")
            {
                // Call Controller.Calc function to calculate the result
                //output = Controller.Calc(output);
                output = controller.CalculateExpression(output);

                if (output.Contains('.'))
                {
                    currentNumIncludesDecimal = true;
                }
                zeroIsAvailable = true;

                // Display the result
                OutputTextBlock.Text = output;
            }
        }
        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            zeroIsAvailable = false;
            currentNumIncludesDecimal = false;
            output = "0";
            OutputTextBlock.Text = output;

        }





        private bool EndsWithOperator(string expression)
        {
            if ((expression.EndsWith('+') || expression.EndsWith('-') || expression.EndsWith('*') || expression.EndsWith('/') || expression.EndsWith('^')))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
