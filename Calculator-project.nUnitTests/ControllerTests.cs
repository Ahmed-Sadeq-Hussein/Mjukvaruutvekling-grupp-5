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

        // Tests the different valid input tokens
        [Test]
        public void SortToTokenList_EqualTest()
        {
            // Assign
            string expression = "2+0-1.x41.41/0.2^π+e";
            List<Token> tokenList = new List<Token>();

            // Act
            tokenList = controller.SortToTokenList(expression);

            // Assert
            Assert.AreEqual("2", tokenList[0].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[1].ToString());
            Assert.AreEqual("0", tokenList[2].ToString());
            Assert.AreEqual("[SubtractOperator]", tokenList[3].ToString());
            Assert.AreEqual("1", tokenList[4].ToString());
            Assert.AreEqual("[MultiplyOperator]", tokenList[5].ToString());
            Assert.AreEqual("41,41", tokenList[6].ToString());
            Assert.AreEqual("[DivideOperator]", tokenList[7].ToString());
            Assert.AreEqual("0,2", tokenList[8].ToString());
            Assert.AreEqual("[ExponentiateOperator]", tokenList[9].ToString());
            Assert.AreEqual("3,14159265", tokenList[10].ToString());
            Assert.AreEqual("[SumOperator]", tokenList[11].ToString());
            Assert.AreEqual("2,71828183", tokenList[12].ToString());
        }

        // Tests the program to see if it throws an InvalidExpressionException when the expression is invalid (when it ends with an operator)
        // Assign
        [TestCase("2+")]
        [TestCase("2-")]
        [TestCase("2x")]
        [TestCase("2/")]
        [TestCase("2^")]
        [TestCase("2+2-3x")]
        public void SortToTokenList_ThrowsExceptionTest1(string expression)
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
        public void CalculateSubexpression_Test()
        {
            // Assign


            // Act


            // Assert

        }

        [Test]
        public void Operate_Test()
        {
            // Assign


            // Act


            // Assert

        }

        [Test]
        public void NumberOfDecimals_Test()
        {
            // Assign


            // Act


            // Assert

        }

        [Test]
        public void CalculateExpression_Test()
        {
            // Assign
            string expression = "2+2";

            // Act
            string result = controller.CalculateExpression(expression);

            // Assert
            Assert.AreEqual("4", result);
        }
    }
}