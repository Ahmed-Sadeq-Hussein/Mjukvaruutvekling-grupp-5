using Calculator.Model;
using Calculator_project.Model;

namespace Calculator_project.nUnitTests
{
    public class ControllerTests
    {
        private Controller.Controller controller { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            controller = new Controller.Controller();
        }

        [Test]
        // These tests are for those tests we made along the way

        public void ASHTESTS()
        {
            Function ash = new AshFunction();
            //Assign
            double awns1 = 1;
            double awns2 = 1.1;
            double awns3 = 0;
            //Act
            awns1 = ash.Execute(new double[] { awns1 });
            awns2 = ash.Execute(new double[] { awns2 });
            awns3 = ash.Execute(new double[] { awns3 });

            //Assert?
            Assert.That(awns2, Is.EqualTo(awns1));
            Assert.That(awns3, Is.EqualTo(awns1));
            Assert.That(awns1, Is.EqualTo(69));

        }

        //Tests the different ways to use include brackets
        [Test]
        public void CalculateExpression_EqualTest()
        {
            //Assign
            string expression = "3x(138/(30+4^2))4/3-7(2/7-1/7)+(4)(1+1)+2cos(1-1)3";

            //Act
            string result = controller.CalculateExpression(expression, true);

            //Assert
            Assert.That(result, Is.EqualTo("25.00000002"));
        }

        [Test]
        public void bracketcontroll_EqualTest1()
        {
            //Assign
            string expression = "(2+2)";

            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.That(returned_expression, Is.EqualTo("4"));
        }

        //Assign
        [TestCase("2(2)")]
        [TestCase("(2)2")]
        public void bracketcontroll_EqualTest2(string expression)
        {
            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.That(returned_expression, Is.EqualTo("2x2"));
        }

        [Test]
        public void bracketcontroll_EqualTest3()
        {
            //Assign
            string expression = "e(2)";

            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.That(returned_expression, Is.EqualTo("ex2"));
        }

        [Test]
        public void bracketcontroll_EqualTest4()
        {
            //Assign
            string expression = "-(2)";

            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.That(returned_expression, Is.EqualTo("-x2"));
        }

        //Assign
        [Test]
        public void functioncontroll_EqualTest1()
        {
            //Assign
            string expression = "cos0";

            //Act
            string returned_string = controller.functioncontroll(expression);

            //Assert
            Assert.That(returned_string, Is.EqualTo("1"));
        }

        [Test]
        public void functioncontroll_EqualTest2()
        {
            //Assign
            string expression = "3tan0";

            //Act
            string returned_string = controller.functioncontroll(expression);

            //Assert
            Assert.That(returned_string, Is.EqualTo("3x0"));
        }

        [Test]
        public void functioncontroll_EqualTest3()
        {
            //Assign
            string expression = "πsin3";

            //Act
            string returned_string = controller.functioncontroll(expression);

            //Assert
            Assert.That(returned_string, Is.EqualTo("πx0.1411200080598672"));
        }

        // Tests the different valid input tokens
        [Test]
        public void SortToTokenList_EqualTest()
        {
            // Assign
            string expression = "2+0-–1.x41.41/0.2^π+e";
            List<Token> tokenList = new List<Token>();

            // Act
            tokenList = controller.SortToTokenList(expression);

            // Assert
            Assert.That(tokenList[0].ToString().Replace('.', ','), Is.EqualTo("2"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[2].ToString().Replace('.', ','), Is.EqualTo("0"));
            Assert.That(tokenList[3].ToString(), Is.EqualTo("[SubtractOperator]"));
            Assert.That(tokenList[4].ToString().Replace('.', ','), Is.EqualTo("-1"));
            Assert.That(tokenList[5].ToString(), Is.EqualTo("[MultiplyOperator]"));
            Assert.That(tokenList[6].ToString().Replace('.', ','), Is.EqualTo("41,41"));
            Assert.That(tokenList[7].ToString(), Is.EqualTo("[DivideOperator]"));
            Assert.That(tokenList[8].ToString().Replace('.', ','), Is.EqualTo("0,2"));
            Assert.That(tokenList[9].ToString(), Is.EqualTo("[ExponentiateOperator]"));
            Assert.That(tokenList[10].ToString().Replace('.', ','), Is.EqualTo("3,14159265"));
            Assert.That(tokenList[11].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[12].ToString().Replace('.', ','), Is.EqualTo("2,71828183"));
        }

        // Tests the program to see if it throws an InvalidExpressionException when the expression is invalid (when it ends with an operator)
        // Assign
        [TestCase("2+")]
        [TestCase("2-")]
        [TestCase("2x")]
        [TestCase("2/")]
        [TestCase("2^")]
        [TestCase("2+2-3x")]
        public void SortToTokenList_ThrowsExceptionTest(string expression)
        {
            // Act, Assert
            Assert.Throws<Calculator_project.Exceptions.InvalidExpressionException>(() => controller.SortToTokenList(expression));
        }

        [Test]
        public void TokenListContainsOperator_SumOperator_IsTrueTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SumOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsTrue(controller.TokenListContainsOperator<SumOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_SumOperator_IsFalseTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsFalse(controller.TokenListContainsOperator<SumOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_SubtractOperator_IsTrueTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsTrue(controller.TokenListContainsOperator<SubtractOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_SubtractOperator_IsFalseTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SumOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsFalse(controller.TokenListContainsOperator<SubtractOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_MultiplyOperator_IsTrueTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.MultiplyOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsTrue(controller.TokenListContainsOperator<MultiplyOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_MultiplyOperator_IsFalseTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsFalse(controller.TokenListContainsOperator<MultiplyOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_DivideOperator_IsTrueTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.MultiplyOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsTrue(controller.TokenListContainsOperator<DivideOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_DivideOperator_IsFalseTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.MultiplyOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsFalse(controller.TokenListContainsOperator<DivideOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_ExponentiateOperator_IsTrueTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.MultiplyOperator(),
                new Model.Operand(3),
                new Model.ExponentiateOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsTrue(controller.TokenListContainsOperator<ExponentiateOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_ExponentiateOperator_IsFalseTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act, Assert
            Assert.IsFalse(controller.TokenListContainsOperator<ExponentiateOperator>(tokenList, ref index));
        }

        [Test]
        public void TokenListContainsOperator_SumOperator_EqualTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SumOperator(),
                new Model.Operand(3),
                new Model.SumOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act
            controller.TokenListContainsOperator<SumOperator>(tokenList, ref index);

            // Assert
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void TokenListContainsOperator_SubtractOperator_EqualTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.SubtractOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act
            controller.TokenListContainsOperator<SubtractOperator>(tokenList, ref index);

            // Assert
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void TokenListContainsOperator_MultiplyOperator_EqualTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.MultiplyOperator(),
                new Model.Operand(3),
                new Model.MultiplyOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act
            controller.TokenListContainsOperator<MultiplyOperator>(tokenList, ref index);

            // Assert
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void TokenListContainsOperator_DivideOperator_EqualTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.DivideOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act
            controller.TokenListContainsOperator<DivideOperator>(tokenList, ref index);

            // Assert
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void TokenListContainsOperator_ExponentiateOperator_EqualTest()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.ExponentiateOperator(),
                new Model.Operand(3),
                new Model.ExponentiateOperator(),
                new Model.Operand(3)
            };
            int index = default;

            // Act
            controller.TokenListContainsOperator<ExponentiateOperator>(tokenList, ref index);

            // Assert
            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void CalculateSubexpression_Test()
        {
            // Assign
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(4),
                new Model.SumOperator(),
                new Model.Operand(3),
                new Model.MultiplyOperator(),
                new Model.Operand(3)
            };
            int index = 3;

            // Act
            tokenList = controller.CalculateSubexpression(tokenList, index);

            // Assert
            Assert.That(tokenList[0].ToString(), Is.EqualTo("4"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[2].ToString(), Is.EqualTo("9"));
        }

        [Test]
        public void Operate_Test()
        {
            // Assign
            List<Token> tokenList = new List<Token>()
            {
                new Model.Operand(2),
                new Model.SumOperator(),
                new Model.Operand(0),
                new Model.MultiplyOperator(),
                new Model.Operand(1),
                new Model.SubtractOperator(),
                new Model.Operand(3),
                new Model.DivideOperator(),
                new Model.Operand(1.5),
                new Model.ExponentiateOperator(),
                new Model.Operand(0)
            };

            // Act, Assert
            tokenList = controller.Operate(tokenList);
            Assert.That(tokenList[0].ToString(), Is.EqualTo("2"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[2].ToString(), Is.EqualTo("0"));
            Assert.That(tokenList[3].ToString(), Is.EqualTo("[MultiplyOperator]"));
            Assert.That(tokenList[4].ToString(), Is.EqualTo("1"));
            Assert.That(tokenList[5].ToString(), Is.EqualTo("[SubtractOperator]"));
            Assert.That(tokenList[6].ToString(), Is.EqualTo("3"));
            Assert.That(tokenList[7].ToString(), Is.EqualTo("[DivideOperator]"));
            Assert.That(tokenList[8].ToString(), Is.EqualTo("1"));

            tokenList = controller.Operate(tokenList);
            Assert.That(tokenList[0].ToString(), Is.EqualTo("2"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[2].ToString(), Is.EqualTo("0"));
            Assert.That(tokenList[3].ToString(), Is.EqualTo("[MultiplyOperator]"));
            Assert.That(tokenList[4].ToString(), Is.EqualTo("1"));
            Assert.That(tokenList[5].ToString(), Is.EqualTo("[SubtractOperator]"));
            Assert.That(tokenList[6].ToString(), Is.EqualTo("3"));

            tokenList = controller.Operate(tokenList);
            Assert.That(tokenList[0].ToString(), Is.EqualTo("2"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SumOperator]"));
            Assert.That(tokenList[2].ToString(), Is.EqualTo("0"));
            Assert.That(tokenList[3].ToString(), Is.EqualTo("[SubtractOperator]"));
            Assert.That(tokenList[4].ToString(), Is.EqualTo("3"));

            tokenList = controller.Operate(tokenList);
            Assert.That(tokenList[0].ToString(), Is.EqualTo("2"));
            Assert.That(tokenList[1].ToString(), Is.EqualTo("[SubtractOperator]"));
            Assert.That(tokenList[2].ToString(), Is.EqualTo("3"));

            tokenList = controller.Operate(tokenList);
            Assert.That(tokenList[0].ToString(), Is.EqualTo("-1"));
        }

        [Test]
        public void NumberOfDecimals_EqualsTest()
        {
            // Assign
            string expression = "1.123456789";

            // Act
            int numberOfDecimals = controller.NumberOfDecimals(expression);

            // Assert
            Assert.That(numberOfDecimals, Is.EqualTo(9));
        }

        [Test]
        public void CalculateComplexExpression_IntegrationTest()
        {
            // Assign
            string expression = "2 + 3 * (4 - 1)";
            string expectedOutput = "11"; 

            // Act
            string result = controller.CalculateExpression(expression, true);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}