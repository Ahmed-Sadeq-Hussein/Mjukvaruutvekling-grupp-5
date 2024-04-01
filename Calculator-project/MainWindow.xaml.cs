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

        bool decimalAvailable = true;

        String output = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            DivideBtn.Content = "\u00f7";


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

        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (decimalAvailable)
            {
                if (output == "")
                {
                    output += "0,";
                    OutputTextBlock.Text = output;
                }
                else
                {
                    output += ",";
                    OutputTextBlock.Text = output;
                }
                decimalAvailable = false;
            }
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Plus";
                decimalAvailable = true;
            }
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Minus";
                decimalAvailable = true;
            }
        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Product";
                decimalAvailable = true;
            }
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Divide";
                decimalAvailable = true;
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
                        OutputTextBlock.Text = "EROR";
                    }
                    break;
            }
            if (output.Contains(','))
            {
                decimalAvailable = false;
            }
            else
            {
                decimalAvailable = true;
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = "0";
            decimalAvailable = true;
        }

        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
