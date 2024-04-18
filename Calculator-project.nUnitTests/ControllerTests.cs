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
        public void SortToTokenList_Test()
        {
            // Assign


            // Act


            // Assert

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