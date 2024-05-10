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

        //Tests the different ways to use include brackets
        [Test]
        public void CalculateExpression_EqualTest()
        {
            //Assign
            string expression = "3x(138/(30+4^2))4/3-7(2/7-1/7)+(4)(1+1)";

            //Act
            string result = controller.CalculateExpression(expression, true);

            //Assert
            Assert.AreEqual("19.00000002", result);
        }

        [Test]
        public void bracketcontroll_EqualTest1()
        {
            //Assign
            string expression = "(2+2)";

            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.AreEqual("4", returned_expression);
        }

        //Assign
        [TestCase("2(2)")]
        [TestCase("(2)2")]
        public void bracketcontroll_EqualTest2(string expression)
        {
            //Act
            string returned_expression = controller.bracketcontroll(expression);

            //Assert
            Assert.AreEqual("2x2", returned_expression);
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
            Assert.AreEqual("2", tokenList[0].ToString().Replace('.', ','));
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("0", tokenList[2].ToString().Replace('.', ','));
            Assert.AreEqual("[SubtractOperator]", tokenList[3].ToString());
            Assert.AreEqual("-1", tokenList[4].ToString().Replace('.', ','));
            Assert.AreEqual("[MultiplyOperator]", tokenList[5].ToString());
            Assert.AreEqual("41,41", tokenList[6].ToString().Replace('.', ','));
            Assert.AreEqual("[DivideOperator]", tokenList[7].ToString());
            Assert.AreEqual("0,2", tokenList[8].ToString().Replace('.', ','));
            Assert.AreEqual("[ExponentiateOperator]", tokenList[9].ToString());
            Assert.AreEqual("3,14159265", tokenList[10].ToString().Replace('.', ','));
            Assert.AreEqual("[SumOperator]", tokenList[11].ToString());
            Assert.AreEqual("2,71828183", tokenList[12].ToString().Replace('.', ','));
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
            Assert.AreEqual(1, index);
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
            Assert.AreEqual(1, index);
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
            Assert.AreEqual(1, index);
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
            Assert.AreEqual(1, index);
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
            Assert.AreEqual(3, index);
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
            Assert.AreEqual("4", tokenList[0].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("9", tokenList[2].ToString());
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
            int index = default;

            // Act, Assert
            tokenList = controller.Operate(tokenList);
            Assert.AreEqual("2", tokenList[0].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("0", tokenList[2].ToString());
            Assert.AreEqual("[MultiplyOperator]", tokenList[3].ToString());
            Assert.AreEqual("1", tokenList[4].ToString());
            Assert.AreEqual("[SubtractOperator]", tokenList[5].ToString());
            Assert.AreEqual("3", tokenList[6].ToString());
            Assert.AreEqual("[DivideOperator]", tokenList[7].ToString());
            Assert.AreEqual("1", tokenList[8].ToString());

            tokenList = controller.Operate(tokenList);
            Assert.AreEqual("2", tokenList[0].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("0", tokenList[2].ToString());
            Assert.AreEqual("[MultiplyOperator]", tokenList[3].ToString());
            Assert.AreEqual("1", tokenList[4].ToString());
            Assert.AreEqual("[SubtractOperator]", tokenList[5].ToString());
            Assert.AreEqual("3", tokenList[6].ToString());

            tokenList = controller.Operate(tokenList);
            Assert.AreEqual("2", tokenList[0].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("0", tokenList[2].ToString());
            Assert.AreEqual("[SubtractOperator]", tokenList[3].ToString());
            Assert.AreEqual("3", tokenList[4].ToString());

            tokenList = controller.Operate(tokenList);
            Assert.AreEqual("2", tokenList[0].ToString());
            Assert.AreEqual("[SubtractOperator]", tokenList[1].ToString());
            Assert.AreEqual("3", tokenList[2].ToString());

            tokenList = controller.Operate(tokenList);
            Assert.AreEqual("-1", tokenList[0].ToString());
        }

        [Test]
        public void NumberOfDecimals_EqualsTest()
        {
            // Assign
            string expression = "1.123456789";

            // Act
            int numberOfDecimals = controller.NumberOfDecimals(expression);

            // Assert
            Assert.AreEqual(9, numberOfDecimals);
        }
    }
}