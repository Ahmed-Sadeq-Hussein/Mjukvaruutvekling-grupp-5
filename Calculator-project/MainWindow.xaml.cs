using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Calculator_project
{
    /// <summary>
    /// 
    /// </summary>

    public partial class MainWindow : Window
    {
        Controller.Controller controller = new Controller.Controller();

        string output = "0"; //used to keep track of the numbers
        bool currentNumIncludesDecimal = false;
        bool zeroIsAvailable = false;
        bool eOrPiIsAvailable = true;
        int parenthesesCount = 0; // Track parentheses count


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// A function that takes the current button content to the output string. 
        /// Smart. very creative
        /// </summary>

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;

            if (eOrPiIsAvailable)
            {
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
                        zeroIsAvailable = true;
                    }
                    else
                    {
                        output += buttonContent;
                    }
                    OutputTextBlock.Text = output;

                }
            }
        }

        /// <summary>
        /// implementation of e or pi. might be redundant considering the button press. Will ask about it .
        /// </summary>
        private void eOrPiBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;

            if (eOrPiIsAvailable)
            {
                eOrPiIsAvailable = false;
                currentNumIncludesDecimal = true;
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
        /// <summary>
        /// Button specifically for decimal. 
        /// Good. does go well with oop and grasp implementation.
        /// </summary>
        
        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the output already contains a decimal point
            if (!currentNumIncludesDecimal)
            {
                if (EndsWithOperator(output) || output.EndsWith("(") || output.EndsWith(")"))
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

        /// <summary>
        /// implementation of the diffrent operators, +, - ect .
        /// Good. Identifies the issue that might occur and adresses it through a simple and compact if statement.
        /// </summary>
        
        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;
            if (!EndsWithOperator(output)) // If the expression does NOT end with an operator, add the pressed operator
            {
                if (buttonContent == "-")
                {
                    if (output == "0")
                    {
                        output = "–";
                    }
                    else 
                    {
                        output += buttonContent;
                    }
                }
                else
                {
                    output += buttonContent;
                }
                zeroIsAvailable = true;
                currentNumIncludesDecimal = false;
                eOrPiIsAvailable = true;
                OutputTextBlock.Text = output;
            }
            else if(buttonContent == "-" && !output.EndsWith('–'))
            {
                zeroIsAvailable = true;
                currentNumIncludesDecimal = false;
                eOrPiIsAvailable = true;
                output += "–";
                OutputTextBlock.Text = output;
            }
        }

        /// <summary>
        /// Implementation of = . This is pretty self explanitory . This also takes into account decimals and waits for controller to do its job before showing awnser.
        /// </summary>
        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {

            if (output != "0")
            {
                // closes all parenthesis in the function. :3
                while (parenthesesCount > 0)
                {
                    output += ")";
                    OutputTextBlock.Text = output;
                    parenthesesCount--;
                }
                // Call Controller.Calc function to calculate the result
                output = controller.CalculateExpression(output);

                if (output.Contains('.'))
                {
                    currentNumIncludesDecimal = true;
                }
                zeroIsAvailable = true;
                eOrPiIsAvailable = true;

                // Display the result
                OutputTextBlock.Text = output;
            }
        }

        /// <summary>
        /// implementation of Clear. Good. Resets values and readresses output and text block.
        /// Well done.
        /// </summary>
        
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            zeroIsAvailable = false;
            currentNumIncludesDecimal = false;
            eOrPiIsAvailable = true;
            output = "0";
            OutputTextBlock.Text = output;

        }

        /// <summary>
        /// A support function. Goes well with previous functions.
        /// could have been put in model but since it is closely knit and only used here.
        /// .......
        /// hint. use this on the ending to delete excess operator in the end of the string to add furthure bug prevention
        /// ......
        /// </summary>
        
        private bool EndsWithOperator(string expression)
        {
            if ((expression.EndsWith('+') || expression.EndsWith('-') || expression.EndsWith('–') || expression.EndsWith('x') || expression.EndsWith('*') || expression.EndsWith('/') || expression.EndsWith('^') || expression.EndsWith("(") || expression.EndsWith(")")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// keyboard input implementation. 
        /// good addition to the calculator and can help with people that use calculator through kepyboard.
        /// </summary>
       
        private void OutputTextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string keyContent = e.Text;

            if ((IsNumber(keyContent)))
            {
                if (eOrPiIsAvailable)
                {
                    if (keyContent == "0") // If the zero button is pressed, check to see if a zeroAvailable is true before adding
                    {
                        if (zeroIsAvailable)
                        {
                            if (EndsWithOperator(output))
                            {
                                zeroIsAvailable = false;
                            }
                            output += keyContent;
                            OutputTextBlock.Text = output;
                        }
                    }
                    else // If any other number button is pressed, add it
                    {
                        if (output == "0")
                        {
                            output = keyContent;
                            zeroIsAvailable = true;
                        }
                        else
                        {
                            output += keyContent;
                        }
                        OutputTextBlock.Text = output;

                    }
                }
            }
            else if(keyContent == "(" || keyContent == ")")
            {
                eOrPiIsAvailable = true;
                currentNumIncludesDecimal = false;
                zeroIsAvailable = true;
                if (output == "0")
                {
                    output = keyContent;
                }
                else
                {
                    output += keyContent;
                }
                OutputTextBlock.Text = output;
            }
            else if (keyContent == "p")
            {
                if (eOrPiIsAvailable)
                {
                    eOrPiIsAvailable = false;
                    currentNumIncludesDecimal = true;
                    if (output == "0")
                    {
                        output = "π";
                    }
                    else
                    {
                        output += "π";
                    }
                    OutputTextBlock.Text = output;
                }
            }
            else if (keyContent == "e")
            {
                if (eOrPiIsAvailable)
                {
                    eOrPiIsAvailable = false;
                    currentNumIncludesDecimal = true;
                    if (output == "0")
                    {
                        output = "e";
                    }
                    else
                    {
                        output += "e";
                    }
                    OutputTextBlock.Text = output;
                }
            }
            else if (keyContent == "," || keyContent == ".")
            {
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
            else if (EndsWithOperator((string)keyContent))
            {
                if (!EndsWithOperator(output))
                {
                    if (keyContent == "*")
                    {
                        output += "x";
                    }
                    else if (keyContent == "-")
                    {
                        if (output == "0")
                        {
                            output = "–";
                        }
                        else
                        {
                            output += keyContent;
                        }
                    }
                    else
                    {
                        output += keyContent;
                    }
                }

                else if (keyContent == "-" && !output.EndsWith('–'))
                {
                    output += "–";
                }

                zeroIsAvailable = true;
                currentNumIncludesDecimal = false;
                eOrPiIsAvailable = true;
                OutputTextBlock.Text = output;
            }
            else if (keyContent == "=")
            {
                if (output != "0")
                {
                    // Call Controller.Calc function to calculate the result
                    output = controller.CalculateExpression(output);

                    if (output.Contains('.'))
                    {
                        currentNumIncludesDecimal = true;
                    }
                    zeroIsAvailable = true;
                    eOrPiIsAvailable |= true;

                    // Display the result
                    OutputTextBlock.Text = output;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// used in keyboard text function
        /// ...........
        /// -should probably be in the model instead of in gui. for cohesion and for model to contain what it is required to contain.
        /// ............
        /// </summary>
        
        private bool IsNumber(string text)
        {
            int number;
            return int.TryParse(text, out number);
        }
        /// <summary>
        /// is used for pressing back or enter key. 
        /// good.
        /// </summary>
        
        private void OutputTextBlock_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Back)
            {
                zeroIsAvailable = false;
                currentNumIncludesDecimal = false;
                eOrPiIsAvailable = true;
                output = "0";
                OutputTextBlock.Text = output;
                e.Handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (output != "0")
                {
                    // Call Controller.Calc function to calculate the result
                    output = controller.CalculateExpression(output);

                    if (output.Contains('.'))
                    {
                        currentNumIncludesDecimal = true;
                    }
                    zeroIsAvailable = true;
                    eOrPiIsAvailable = true;

                    // Display the result
                    OutputTextBlock.Text = output;
                }
                e.Handled = true;
            }
        }

        private void OpenParentheses_Btn_Click(object sender, RoutedEventArgs e)
            {
               
                parenthesesCount++;
                output += "(";
                OutputTextBlock.Text = output;
            // braket variable changes. included in both .
            currentNumIncludesDecimal = false;
            eOrPiIsAvailable = true;
            zeroIsAvailable = true;
            }


        private void CloseParentheses_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (parenthesesCount > 0) // Ensure there are open parentheses to close
            {
                parenthesesCount--;
                output += ")";
                OutputTextBlock.Text = output;
            }
            


        }

        private void Sinus_Btn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = "sin(";

                currentNumIncludesDecimal = true;
                output += buttonContent;
                OutputTextBlock.Text = output;
            
        }

        private void Cosinus_Btn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = "cos(";

            
                output += buttonContent;
                OutputTextBlock.Text = output;
            
        }

        private void Tanges_Btn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = "tan(";

          
                output += buttonContent;
                OutputTextBlock.Text = output;
            
        }

    }
}

//Good coded 