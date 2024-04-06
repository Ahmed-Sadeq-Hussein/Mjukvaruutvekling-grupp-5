using Calculator.Model;
using Calculator_project.Exceptions;
using Calculator_project.Model;
using System;
using System.Collections.Generic;
using System.Windows;
namespace Calculator_project.Controller
{
    internal class Controller
    {
        //private static Queue<Equation> equationQueue = new Queue<Equation>(10);

        public string CalculateExpression(string expression)
        {
            List<Token> tokenList = new List<Token>();

            try
            {
                tokenList = SortToTokenList(expression); // Turn the expression string into a List of Tokens
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return expression;
            }

            try
            {
                while (tokenList.Count > 1)
                {
                    tokenList = Operate(tokenList);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return expression;
            }

            // The expression had no errors! :)
            // Now return the answer and add both the expression and its answer to the equationQueue
            //if (equationQueue.Count == 10)
            //{
            //    equationQueue.Dequeue();
            //}
            //equationQueue.Enqueue(new Equation(expression, tokenList[0].ToString()));


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
            if ((index = TokenListContainsOperator(tokenList, "[ExponentiateOperator]")) != -1)
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if ((index = TokenListContainsOperator(tokenList, "[DivideOperator]")) != -1)
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if ((index = TokenListContainsOperator(tokenList, "[MultiplyOperator]")) != -1)
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if ((index = TokenListContainsOperator(tokenList, "[SumOperator]")) != -1)
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if ((index = TokenListContainsOperator(tokenList, "[SubtractOperator]")) != -1)
            {
                return CalculateSubexpression(tokenList, index);
            }
            else
            {
                throw new InvalidExpressionException();
            }
        }

        // Returns the index of the left-most given operator type, if none is found, return -1
        private int TokenListContainsOperator(List<Token> tokenList, string @operator)
        {
            for (int i = tokenList.Count; i > 0; i--)
            {
                if (tokenList[i].ToString() == @operator)
                {
                    return i;
                }
            }
            return -1;
        }

        private List<Token> CalculateSubexpression(List<Token> tokenList, int index)
        {
            // Define the operator and its related operands
            Operator currentOperator = (Operator)tokenList[index];
            Operand firstOperand = (Operand)tokenList[index - 1];
            Operand secondOperand = (Operand)tokenList[index + 1];

            // Compute the result
            double result = currentOperator.Compute(firstOperand.value, secondOperand.value);

            //Remove the handled tokens from the list and replace them with the result
            tokenList.RemoveRange(index - 1, index + 1);
            tokenList.Insert(index - 1, new Operand(result));
            return tokenList;
        }
    }
}
