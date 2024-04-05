using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double temp = 0;
        string operation = "";
        string answer; 

        String output = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            // DivideBtn.Content = "\u00f7";


        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            if (((string)((Button)sender).Content) == "0")
            {
                if (output != "")
                {
                    output += ((Button)sender).Content;
                    OutputTextBlock.Text = output;
                }
            }
            else
            {
                output += ((Button)sender).Content;
                OutputTextBlock.Text = output;
            }
        }
       

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            double outputTemp;

            switch (operation)
            {
                case "Minus":
                    outputTemp = temp - double.Parse(output);
                    output = outputTemp.ToString();
                    OutputTextBlock.Text = output;
                    break;

                case "Plus":
                    outputTemp = temp + double.Parse(output);
                    output = outputTemp.ToString();
                    OutputTextBlock.Text = output;
                    break;

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

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            output += Math.PI.ToString();
            OutputTextBlock.Text = output;
        }

        private void e_Btn_Click(object sender, RoutedEventArgs e)
        {
            output += Math.E.ToString();
            OutputTextBlock.Text = output;
        }



    }
}
//hej