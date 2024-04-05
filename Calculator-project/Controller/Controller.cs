using Calculator_project.Exceptions;
using System;
using System.Collections.Generic;
using System.Windows;
namespace Calculator_project.Controller
{
    internal class Controller
    {
        public string CalculateExpression(string expression)
        {

            try
            {
                List<Token> tokenList = SortToTokenList(expression); // Turn the expression string into a List of Tokens
            }
            catch (InvalidExpressionException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return expression;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return expression;
            }
            while (tokenList.Count > 1)
            {
                tokenList = Operate(tokenList);
            }

            return tokenList[0].ToString();
        }


        private List<Token> SortToTokenList(string expression)
        {
            List<Token> tokenList = new List<Token>();

            string tempNumber = "";
            double doubleTempNumber = 0.0;
            for (int i = 0; i < expression.Length; i++) // Loop through the expression string
            {
                if (char.IsDigit(expression[i]) || expression[i] == '.') // If the current char is a number [0-9] or a decimal [,], add it to the tempNumber
                {
                    tempNumber += expression[i];
                }
                else if (expression[i] == '+' || expression[i] == '–' || expression[i] == '*' || expression[i] == '/' || expression[i] == '^') // If the current char is an operator symbol [+|-|*|/|^], add the previous number (tempNumber) to the list and add the operator to the list
                {
                    doubleTempNumber = Double.Parse((string)tempNumber, System.Globalization.NumberStyles.Float);
                    tokenList.Add(new Operand(doubleTempNumber));
                    tempNumber = "";

                    switch (expression[i])
                    {
                        case '+':
                            tokenList.Add(new SumOperator());
                            break;

                        case '-':
                            tokenList.Add(new SubtractOperator());
                            break;

                        case '*':
                            tokenList.Add(new MultiplyOperator());
                            break;

                        case '/':
                            tokenList.Add(new DivideOperator());
                            break;

                        case '^':
                            tokenList.Add(new ExponentiateOperator());
                            break;
                    }
                }
            }
            if (tempNumber.Length == 0) // We just exited the loop through the expression, and tempNumber is empty, this means that either the expression ends with an operator or the expression is empty, throw an expection
            {
                throw new InvalidExpressionException();
            }
            else // Not invalidities yet detected
            {
                doubleTempNumber = Double.Parse((string)tempNumber, System.Globalization.NumberStyles.Float);
                tokenList.Add(new Operand(doubleTempNumber));
            }

            return tokenList;
        }

        private List<Token> Operate(List<Token> tokenList)
        {
            int index = 0;
            // Handle the operators in the correct order: [^] => [/] => [*] => [+] => [-]
            if (tokenList.Contains(ExponentiateOperator))
            {
                index = tokenList.LastIndexOf(ExponentiateOperator);
                return CalculateSubexpression(tokenList, index);

            }
            else if (tokenList.Contains(DivideOperator))
            {
                index = tokenList.IndexOf(DivideOperator);
                return CalculateSubexpression(tokenList, index);

            }
            else if (tokenList.Contains(MultiplyOperator))
            {
                index = tokenList.IndexOf(MultiplyOperator);
                return CalculateSubexpression(tokenList, index);

            }
            else if (tokenList.Contains(SumOperator))
            {
                index = tokenList.IndexOf(SumOperator);
                return CalculateSubexpression(tokenList, index);

            }
            else if (tokenList.Contains(SubtractOperator))
            {
                index = tokenList.IndexOf(SubtractOperator);
                return CalculateSubexpression(tokenList, index);

            }
        }

        private List<Token> CalculateSubexpression(List<Token> tokenList, int index)
        {
            // Define the operator and its related operands
            Operator currentOperator = tokenList[index];
            Operand firstOperand = tokenList[index - 1];
            Operand secondOperand = tokenList[index + 1];

            // Compute the result
            double result = currentOperator.compute(firstOperand.value, secondOperand.value);

            //Remove the handled tokens from the list and replace them with the result
            tokenList.RemoveRange(index - 1, index + 1);
            tokenList.Insert(index - 1, new Operand(result));
            return tokenList;
        }
    }
}
