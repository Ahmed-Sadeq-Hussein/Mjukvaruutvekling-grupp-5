namespace Calculator_project
{
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///  creates a file to save stuff inside.
        ///
        /// </summary>
        ///
        private Controller.Controller controller = new Controller.Controller();

        private string output = "0"; // used to keep track of the numbers
        private bool currentNumIncludesDecimal = false;
        private string filePath = "yourfile.txt";
        private bool numIsAvailable = true;

        private bool zeroIsAvailable = false;
        private bool eOrPiIsAvailable = true;
        private int parenthesesCount = 0; // Track parentheses count

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;

            if (!File.Exists(this.filePath))
            {
                File.Create(this.filePath).Dispose();
            }
            else
            {
                File.WriteAllText(this.filePath, string.Empty);
            }
        }

        /// <summary>
        /// A function that takes the current button content to the output string.
        /// Smart. very creative.
        /// </summary>
        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;

            if (this.eOrPiIsAvailable)
            {
                if (buttonContent == "0") // If the zero button is pressed, check to see if a zeroAvailable is true before adding
                {
                    if (this.zeroIsAvailable)
                    {
                        if (this.EndsWithOperator(this.output))
                        {
                            this.numIsAvailable = false;
                            this.zeroIsAvailable = false;
                        }

                        this.output += buttonContent;
                        this.OutputTextBlock.Text = this.output;
                    }
                }
                else // If any other number button is pressed, add it
                {
                    if (this.numIsAvailable)
                    {
                        if (this.output == "0" || this.output == "0 ")
                        {
                            this.output = buttonContent;
                            this.zeroIsAvailable = true;
                        }
                        else
                        {
                            this.output += buttonContent;
                        }

                        this.OutputTextBlock.Text = this.output;
                    }
                }
            }
        }

        /// <summary>
        /// implementation of e or pi. might be redundant considering the button press. Will ask about it .
        /// </summary>
        private void EOrPiBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;

            if (this.eOrPiIsAvailable)
            {
                this.eOrPiIsAvailable = false;
                this.currentNumIncludesDecimal = true;
                if (this.output == "0" || this.output == "0 ")
                {
                    this.output = buttonContent;
                }
                else
                {
                    this.output += buttonContent;
                }

                this.OutputTextBlock.Text = this.output;
            }
        }

        /// <summary>
        /// Button specifically for decimal.
        /// Good. does go well with oop and grasp implementation.
        /// </summary>
        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the output already contains a decimal point
            if (!this.currentNumIncludesDecimal)
            {
                if (this.EndsWithOperator(this.output) || this.output.EndsWith("(") || this.output.EndsWith(")"))
                {
                    this.output += "0.";
                }
                else
                {
                    this.output += '.';
                }

                this.numIsAvailable = true;
                this.zeroIsAvailable = true;
                this.OutputTextBlock.Text = this.output;
                this.currentNumIncludesDecimal = true;
            }
        }

        /// <summary>
        /// implementation of the diffrent operators, +, - ect.
        /// Good. Identifies the issue that might occur and adresses it through a simple and compact if statement.
        /// </summary>
        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)sender).Content;
            if (!this.EndsWithOperator(this.output)) // If the expression does NOT end with an operator, add the pressed operator
            {
                if (buttonContent == "-")
                {
                    if (this.output == "0" || this.output == "0 ")
                    {
                        this.output = "–";
                    }
                    else
                    {
                        this.output += buttonContent;
                    }
                }
                else
                {
                    this.output += buttonContent;
                }

                this.numIsAvailable = true;
                this.zeroIsAvailable = true;
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.OutputTextBlock.Text = this.output;
            }
            else if (buttonContent == "-" && !this.output.EndsWith('–'))
            {
                this.numIsAvailable = true;
                this.zeroIsAvailable = true;
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.output += "–";
                this.OutputTextBlock.Text = this.output;
            }
        }

        /// <summary>
        /// Implementation of = . This is pretty self explanitory . This also takes into account decimals and waits for controller to do its job before showing awnser.
        /// </summary>
        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.output != "0")
            {
                // closes all parenthesis in the function. :3
                while (this.parenthesesCount > 0)
                {
                    this.output += ")";
                    this.OutputTextBlock.Text = this.output;
                    this.parenthesesCount--;
                }

                using (StreamWriter sw = File.AppendText(this.filePath))
                {
                    sw.WriteLine(this.output + "=");
                }

                // Call Controller.Calc function to calculate the result
                this.output = this.controller.CalculateExpression(this.output, true);

                if (this.output.Contains('.'))
                {
                    this.currentNumIncludesDecimal = true;
                }
                else
                {
                    this.currentNumIncludesDecimal = false;
                }

                this.zeroIsAvailable = true;
                this.numIsAvailable = true;
                this.eOrPiIsAvailable = true;

                // Display the result
                if (this.output == "0 ")
                {
                    this.output = "0";
                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine("Error");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine(this.output);
                    }
                }

                this.OutputTextBlock.Text = this.output;
            }
        }

        /// <summary>
        /// implementation of Clear. Good. Resets values and readresses output and text block.
        /// Well done.
        /// </summary>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            this.numIsAvailable = true;
            this.zeroIsAvailable = false;
            this.currentNumIncludesDecimal = false;
            this.eOrPiIsAvailable = true;
            this.parenthesesCount = 0;
            this.output = "0";
            this.OutputTextBlock.Text = this.output;
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
            if (expression.EndsWith('+') || expression.EndsWith('-') || expression.EndsWith('–') || expression.EndsWith('x') || expression.EndsWith('*') || expression.EndsWith('/') || expression.EndsWith('^') || expression.EndsWith("("))
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
            if (this.IsNumber(keyContent))
            {
                if (this.eOrPiIsAvailable)
                {
                    if (keyContent == "0") // If the zero button is pressed, check to see if a zeroAvailable is true before adding
                    {
                        if (this.zeroIsAvailable)
                        {
                            if (this.EndsWithOperator(this.output))
                            {
                                this.numIsAvailable = false;
                                this.zeroIsAvailable = false;
                            }

                            this.output += keyContent;
                            this.OutputTextBlock.Text = this.output;
                        }
                    }
                    else // If any other number button is pressed, add it
                    {
                        if (this.numIsAvailable)
                        {
                            if (this.output == "0" || this.output == "0 ")
                            {
                                this.output = keyContent;
                                this.zeroIsAvailable = true;
                            }
                            else
                            {
                                this.output += keyContent;
                            }

                            this.OutputTextBlock.Text = this.output;
                        }
                    }
                }
            }

            // here is an example of how to add it to the OutputTextBlock_PreviewTextInput method
            else if (keyContent == "A")
            {
                if (this.output == "0" || this.output == "0 ")
                {
                    this.output = string.Empty;
                }

                string buttonContent = "ash(";

                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.zeroIsAvailable = true;
                this.numIsAvailable = true;
                this.parenthesesCount++;
                this.output += buttonContent;
                this.OutputTextBlock.Text = this.output;
            }
            else if (keyContent == "(")
            {
                this.parenthesesCount++;
                if (this.output == "0" || this.output == "0 ")
                {
                    this.output = "(";
                }
                else
                {
                    this.output += "(";
                }

                this.OutputTextBlock.Text = this.output;

                // braket variable changes. included in both .
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.zeroIsAvailable = true;
                this.numIsAvailable = true;
            }
            else if (keyContent == ")")
            {
                if (this.parenthesesCount > 0) // Ensure there are open parentheses to close
                {
                    this.currentNumIncludesDecimal = false;
                    this.eOrPiIsAvailable = true;
                    this.zeroIsAvailable = true;
                    this.numIsAvailable = true;
                    this.parenthesesCount--;
                    this.output += ")";
                    this.OutputTextBlock.Text = this.output;
                }
            }
            else if (keyContent == "p")
            {
                if (this.eOrPiIsAvailable)
                {
                    this.eOrPiIsAvailable = false;
                    this.currentNumIncludesDecimal = true;
                    if (this.output == "0" || this.output == "0 ")
                    {
                        this.output = "π";
                    }
                    else
                    {
                        this.output += "π";
                    }

                    this.OutputTextBlock.Text = this.output;
                }
            }
            else if (keyContent == "e")
            {
                if (this.eOrPiIsAvailable)
                {
                    this.eOrPiIsAvailable = false;
                    this.currentNumIncludesDecimal = true;
                    if (this.output == "0" || this.output == "0 ")
                    {
                        this.output = "e";
                    }
                    else
                    {
                        this.output += "e";
                    }

                    this.OutputTextBlock.Text = this.output;
                }
            }
            else if (keyContent == "," || keyContent == ".")
            {
                if (!this.currentNumIncludesDecimal)
                {
                    if (this.EndsWithOperator(this.output))
                    {
                        this.output += "0.";
                    }
                    else
                    {
                        this.output += '.';
                    }

                    this.numIsAvailable = true;
                    this.zeroIsAvailable = true;
                    this.OutputTextBlock.Text = this.output;
                    this.currentNumIncludesDecimal = true;
                }
            }
            else if (this.EndsWithOperator((string)keyContent))
            {
                if (!this.EndsWithOperator(this.output))
                {
                    if (keyContent == "*")
                    {
                        this.output += "x";
                    }
                    else if (keyContent == "-")
                    {
                        if (this.output == "0" || this.output == "0 ")
                        {
                            this.output = "–";
                        }
                        else
                        {
                            this.output += keyContent;
                        }
                    }
                    else
                    {
                        this.output += keyContent;
                    }
                }
                else if (keyContent == "-" && !this.output.EndsWith('–'))
                {
                    this.output += "–";
                }

                this.numIsAvailable = true;
                this.zeroIsAvailable = true;
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.OutputTextBlock.Text = this.output;
            }
            else if (keyContent == "=")
            {
                if (this.output != "0")
                {
                    while (this.parenthesesCount > 0)
                    {
                        this.output += ")";
                        this.OutputTextBlock.Text = this.output;
                        this.parenthesesCount--;
                    }

                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine(this.output + "=");
                    }

                    // Call Controller.Calc function to calculate the result
                    this.output = this.controller.CalculateExpression(this.output, true);

                    if (this.output.Contains('.'))
                    {
                        this.currentNumIncludesDecimal = true;
                    }

                    this.numIsAvailable = true;
                    this.zeroIsAvailable = true;
                    this.eOrPiIsAvailable |= true;

                    // Display the result
                    this.OutputTextBlock.Text = this.output;
                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine(this.output);
                    }
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
                this.numIsAvailable = true;
                this.zeroIsAvailable = false;
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.parenthesesCount = 0;
                this.output = "0";
                this.OutputTextBlock.Text = this.output;
                e.Handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (this.output != "0")
                {
                    while (this.parenthesesCount > 0)
                    {
                        this.output += ")";
                        this.OutputTextBlock.Text = this.output;
                        this.parenthesesCount--;
                    }

                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine(this.output + "=");
                    }

                    // Call Controller.Calc function to calculate the result
                    this.output = this.controller.CalculateExpression(this.output, true);

                    if (this.output.Contains('.'))
                    {
                        this.currentNumIncludesDecimal = true;
                    }

                    this.numIsAvailable = true;
                    this.zeroIsAvailable = true;
                    this.eOrPiIsAvailable = true;

                    // Display the result
                    this.OutputTextBlock.Text = this.output;
                    using (StreamWriter sw = File.AppendText(this.filePath))
                    {
                        sw.WriteLine(this.output);
                    }
                }

                e.Handled = true;
            }
        }

        private void OpenParentheses_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.parenthesesCount++;
            if (this.output == "0" || this.output == "0 ")
            {
                this.output = "(";
            }
            else
            {
                this.output += "(";
            }

            this.OutputTextBlock.Text = this.output;

            // braket variable changes. included in both .
            this.currentNumIncludesDecimal = false;
            this.eOrPiIsAvailable = true;
            this.zeroIsAvailable = true;
            this.numIsAvailable = true;
        }

        private void CloseParentheses_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.parenthesesCount > 0) // Ensure there are open parentheses to close
            {
                this.currentNumIncludesDecimal = false;
                this.eOrPiIsAvailable = true;
                this.zeroIsAvailable = true;
                this.numIsAvailable = true;
                this.parenthesesCount--;
                this.output += ")";
                this.OutputTextBlock.Text = this.output;
            }
        }

        private void Sinus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.output == "0" || this.output == "0 ")
            {
                this.output = string.Empty;
            }

            string buttonContent = "sin(";

            this.currentNumIncludesDecimal = false;
            this.eOrPiIsAvailable = true;
            this.zeroIsAvailable = true;
            this.numIsAvailable = true;
            this.parenthesesCount++;
            this.output += buttonContent;
            this.OutputTextBlock.Text = this.output;
        }

        private void Cosinus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.output == "0" || this.output == "0 ")
            {
                this.output = string.Empty;
            }

            string buttonContent = "cos(";

            this.currentNumIncludesDecimal = false;
            this.eOrPiIsAvailable = true;
            this.zeroIsAvailable = true;
            this.numIsAvailable = true;
            this.parenthesesCount++;
            this.output += buttonContent;
            this.OutputTextBlock.Text = this.output;
        }

        private void Tanges_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.output == "0" || this.output == "0 ")
            {
                this.output = string.Empty;
            }

            string buttonContent = "tan(";

            this.currentNumIncludesDecimal = false;
            this.eOrPiIsAvailable = true;
            this.zeroIsAvailable = true;
            this.numIsAvailable = true;
            this.parenthesesCount++;
            this.output += buttonContent;
            this.OutputTextBlock.Text = this.output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveFileProtocol(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", this.filePath);
        }
    }
}

// Good coded