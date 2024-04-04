namespace Calculator_project.Controller
{
    internal class Controller
    {
        public string Calculate(string expression)
        {
            new List<Token> sortToTokenList(expression);

            // 1. Sort string to an array or list of Tokens
            // 2. Loop until array.Length() == 1:
            //  3. Check for existing operators in expression: Exponentiation, division, multiplication, addition, subtraction
            //  4. Replace [operand1, operator, operand2] with operand(value), where we get value from operator.Compute(operand1, operand2)
            // 5. Return array[0].ToString
            return "Answer";
        }

        private List<Token> sortToTokenList(string expression)
        {
            List<Token> tokenList = new List<Token>();

            string tempNumber = "";
            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]) || expression[i] == ',') // If the current char is a number [0-9] or a decimal [,], add it to the tempNumber
                {
                    tempNumber += expression[i];
                }
                else if (expression[i] == '+' || expression[i] == '–' || expression[i] == '*' || expression[i] == '/' || expression[i] == '^') // If the current char is an operator symbol [+|-|*|/|^], add the previous number (tempNumber) to the list and add the operator to the list
                {
                    tokenList.Add(new Operand(tempNumber));
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
        }
    }
}
