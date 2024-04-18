using Calculator.Model;

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
        public void SortToTokenList_EqualTest()
        {
            // Assign
            string expression = "2+0-1.x41.41/0.2^1";
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
            Assert.AreEqual("1", tokenList[10].ToString());
        }

        [Test]
        public void SortToTokenList_ThrowsExceptionTest1()
        {
            // Assign
            string expression = "2+";

            // Act

            // Assert
            Assert.Throws<Calculator_project.Exceptions.InvalidExpressionException>(() => controller.SortToTokenList(expression));
        }

        [Test]
        public void SortToTokenList_ThrowsExceptionTest2()
        {
            // Assign
            string expression = "2+";

            // Act

            // Assert
            Assert.Throws<Calculator_project.Exceptions.InvalidExpressionException>(() => controller.SortToTokenList(expression));
        }

        [Test]
        public void TokenListContainsOperator_Test()
        {
            // Assign


            // Act


            // Assert

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