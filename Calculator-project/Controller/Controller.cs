using Calculator.Model;
using Calculator_project.Exceptions;
using Calculator_project.Model;
using System;
using System.Collections.Generic;
using System.Windows;
namespace Calculator_project.Controller
{
    // Ash pull request update

    public class Controller
    {


        //private static Queue<Equation> equationQueue = new Queue<Equation>(10);
        public string bracketcontroll(string exp)
        {
            string expression = exp;
            string calc_exp;
            while (expression.Contains("("))
            {
                /// step one. Find first (
                /// second step find last )
                /// Third step. take string between , run calculate expression, Then replace the brackets.
                int x = 0;
                int y = 0;
                int b_counter = 0;
                bool success = false;
                int numba;
                for (int i = 0; i < expression.Length; i++)
                {
                    if (expression[i] == '(')
                    {
                        if (b_counter == 0) { x = i; b_counter++; }
                        else { b_counter++; }
                    }
                    if (expression[i] == ')')
                    {
                        if (b_counter == 1) { y = i; b_counter--; success = true; }
                        else { b_counter--; }
                    }
                    if (success)
                    {
                        // now to cut . calculate whats inside the brackets and then replace what was cut
                        calc_exp = expression.Substring(x + 1, y - x - 1); //cuts the part of the brackets
                        calc_exp = CalculateExpression(calc_exp); // calculates whats

                        /// to better this and make it able to interprite if multiplication method is required we ask of
                        /// if expression[x-1] isnt operator, if it isnt we add a "*" . test case first paranthesis [0].
                        /// if expression[y+1] isnt operator, if it isnt we add a "*" test case last parenthesis [len -1]
                        /// isnt operator is if the spot is occupied with either a (,) or a number.
                        if (x > 0)
                        {
                            if (expression[x - 1] == ')' || expression[x - 1] == ',' || expression[x - 1] == '-' || int.TryParse(expression[x - 1].ToString(), out numba)) { calc_exp = "x" + calc_exp; }
                        }
                        if (y < expression.Length - 1)
                        {
                            if (expression[y + 1] == '(' || expression[y + 1] == ',' || expression[y + 1] == '-' || int.TryParse(expression[y + 1].ToString(), out numba)) { calc_exp = calc_exp + "x"; }
                        }

                        expression = expression.Substring(0, x) + calc_exp + expression.Substring(y + 1);
                        success = false;
                        break;
                    }
                }
            }
            return expression;
        }

        public string CalculateExpression(string exp)
        {
            List<Token> tokenList = new List<Token>();
            string expression = bracketcontroll(exp);
            string answer;
            double doubleAnswer;

            try
            {
                tokenList = SortToTokenList(expression); // Turn the expression string into a List of 

                while (tokenList.Count > 1)
                {
                    tokenList = Operate(tokenList);
                }

                answer = (tokenList[0].ToString()).Replace(",", ".");
                doubleAnswer = 0.0;

                doubleAnswer = Convert.ToDouble(answer, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return expression;
            }
            if (NumberOfDecimals(answer) > 8)
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

        public List<Token> SortToTokenList(string expression)
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
                    else // Else, a number precedes it, add the preceding number, a MuliplyOperator, and then the current char as an operand. Also operate the newly added subexpression now, since this needs top priority
                    {
                        if (tempNumber == "-")
                        {
                            doubleTempNumber = -1;
                        }
                        else
                        {
                            doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        tempNumber = ((doubleTempNumber * Math.PI).ToString()).Replace(',', '.');
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
                        if (tempNumber == "-")
                        {
                            doubleTempNumber = -1;
                        }
                        else
                        {
                            doubleTempNumber = Convert.ToDouble(tempNumber, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        tempNumber = ((doubleTempNumber * Math.E).ToString()).Replace(',', '.');

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

        public List<Token> Operate(List<Token> tokenList)
        {
            int index = 0;
            // Handle the operators in the correct order: [^] => [/] => [*] => [+]&[-]
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
            else if (TokenListContainsOperator<SumOperator>(tokenList, ref index) || TokenListContainsOperator<SubtractOperator>(tokenList, ref index))
            {
                return CalculateSubexpression(tokenList, 1);
            }
            else
            {
                throw new InvalidExpressionException();
            }
        }

        // Returns the index of the left-most given operator type, if none is found, return -1
        public bool TokenListContainsOperator<T>(List<Token> tokenList, ref int index)
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

        public List<Token> CalculateSubexpression(List<Token> tokenList, int index)
        {
            // Define the operator and its related operands
            Operator currentOperator = (Operator)tokenList[index];
            Operand firstOperand = (Operand)tokenList[index - 1];
            Operand secondOperand = (Operand)tokenList[index + 1];

            // Compute the result
            double result = currentOperator.Compute(firstOperand.value, secondOperand.value);

            if (result == double.PositiveInfinity)
            {
                throw new NumberTooLargeException();
            }

            //Remove the handled tokens from the list and replace them with the result
            tokenList.RemoveRange(index - 1, 3);
            tokenList.Insert(index - 1, new Operand(result));

            return tokenList;
        }

        public int NumberOfDecimals(string answer)
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
