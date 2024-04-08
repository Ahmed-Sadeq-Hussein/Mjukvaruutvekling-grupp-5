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




            string answer = (tokenList[0].ToString()).Replace(",", ".");
            double doubleAnswer = Convert.ToDouble(answer, System.Globalization.CultureInfo.InvariantCulture);

            if (numberOfDecimals(answer) > 8)
            {
                answer = (doubleAnswer.ToString($"F{8}")).Replace(',', '.');
            }
            else
            {
                answer = (doubleAnswer.ToString()).Replace(',', '.');
            }

            answer = answer.Replace("-", "–");
            return answer;
        }

        private List<Token> SortToTokenList(string expression)
        {
            List<Token> tokenList = new List<Token>();

            string tempNumber = "";
            double doubleTempNumber;
            for (int i = 0; i < expression.Length; i++) // Loop through the expression string
            {
                if (char.IsDigit(expression[i]) || expression[i] == '.') // If the current char is a number [0-9] or a decimal [,], add it to the tempNumber
                {
                    tempNumber += expression[i];
                }
                else if (expression[i] == 'π') // If the current char is [π] or [e]
                {
                    if (i == 0 || expression[i - 1] == '+' || expression[i - 1] == '-' || expression[i - 1] == 'x' || expression[i - 1] == '/' || expression[i - 1] == '^') // Check to see if it is the first char or if an operator preceded it, if this is the case, add it to the list
                    {
                        tempNumber = (Math.PI.ToString()).Replace(',', '.');
                    }
                    else // Else, a number precedes it, add the preceding number, a MuliplyOperator, and then the current char as an operand
                    {
                        doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                        tokenList.Add(new Operand(doubleTempNumber));
                        tempNumber = "";
                        tokenList.Add(new MultiplyOperator());
                        tempNumber = (Math.PI.ToString()).Replace(',', '.');
                    }
                }
                else if (expression[i] == 'e')
                {
                    if (i == 0 || expression[i - 1] == '+' || expression[i - 1] == '-' || expression[i - 1] == 'x' || expression[i - 1] == '/' || expression[i - 1] == '^') // Check to see if it is the first char or if an operator preceded it, if this is the case, add it to the list
                    {
                        tempNumber = (Math.E.ToString()).Replace(',', '.');
                    }
                    else // Else, a number precedes it, add the preceding number, a MuliplyOperator, and then the current char as an operand
                    {
                        doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                        tokenList.Add(new Operand(doubleTempNumber));
                        tempNumber = "";
                        tokenList.Add(new MultiplyOperator());
                        tempNumber = (Math.E.ToString()).Replace(',', '.');
                    }
                }
                else if (expression[i] == '+' || expression[i] == '-' || expression[i] == 'x' || expression[i] == '/' || expression[i] == '^') // If the current char is an operator symbol [+|-|*|/|^], add the previous number (tempNumber) to the list and add the operator to the list
                {
                    doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                    tempNumber = (doubleTempNumber.ToString($"F{8}")).Replace(',', '.');
                    doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
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

                        case 'x':
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
                else if (expression[i] == '–')
                {
                    tempNumber += '-';
                }
            }
            if (tempNumber.Length == 0) // We just exited the loop through the expression, and tempNumber is empty, this means that either the expression ends with an operator or the expression is empty, throw an expection
            {
                throw new InvalidExpressionException();
            }
            else // Not invalidities yet detected
            {
                if (expression.EndsWith("π"))
                {
                    doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                    tempNumber = (doubleTempNumber.ToString($"F{8}")).Replace(',', '.');
                }
                else if (expression.EndsWith("e"))
                {
                    doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                    tempNumber = (doubleTempNumber.ToString($"F{8}")).Replace(',', '.');
                }
                doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                tokenList.Add(new Operand(doubleTempNumber));
            }

            return tokenList;
        }

        private List<Token> Operate(List<Token> tokenList)
        {
            int index = 0;
            // Handle the operators in the correct order: [^] => [/] => [*] => [+] => [-]
            if (TokenListContainsOperator<ExponentiateOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if (TokenListContainsOperator<DivideOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if (TokenListContainsOperator<MultiplyOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if (TokenListContainsOperator<SumOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, index);
            }
            else if (TokenListContainsOperator<SubtractOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, index);
            }
            else
            {
                throw new InvalidExpressionException();
            }
        }

        // Returns the index of the left-most given operator type, if none is found, return -1
        private bool TokenListContainsOperator<T>(List<Token> tokenList, ref int index)
        {
            ExponentiateOperator comparisonOperator = new ExponentiateOperator();



            if (comparisonOperator is T)
            {
                for (int i = tokenList.Count - 1; i > 0; i--)
                {
                    if (tokenList[i] is T)
                    {
                        index = i;
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < tokenList.Count; i++)
                {
                    if (tokenList[i] is T)
                    {
                        index = i;
                        return true;
                    }
                }
            }
            return false;
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
            tokenList.RemoveRange(index - 1, 3);
            tokenList.Insert(index - 1, new Operand(result));

            return tokenList;
        }

        private int numberOfDecimals(string answer)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == '.')
                {
                    return answer.Length - i - 1;
                }
            }
            return 0;
        }
    }
}
