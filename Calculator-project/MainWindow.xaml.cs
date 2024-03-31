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
            String name = ((Button)sender).Name;

            switch(name)
            {
                case "OneBtn":
                    output += "1";
                    OutputTextBlock.Text = output;

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

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Minus";
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
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;

        }

        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
