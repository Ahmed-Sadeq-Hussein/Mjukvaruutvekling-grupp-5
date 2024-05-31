namespace Calculator_project.nUnitTests
{
    using Calculator_project.Model;

    public class ModelTests
    {
        [Test]
        public void SumOperator_EqualTest1()
        {
            // Assign
            SumOperator oPerator = new SumOperator();
            double x = 1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void SumOperator_EqualTest2()
        {
            // Assign
            SumOperator oPerator = new SumOperator();
            double x = -1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SumOperator_EqualTest3()
        {
            // Assign
            SumOperator oPerator = new SumOperator();
            double x = 1.8;
            double y = 2.123;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(3.923));
        }

        [Test]
        public void SubtractOperator_EqualTest1()
        {
            // Assign
            SubtractOperator oPerator = new SubtractOperator();
            double x = 1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void SubtractOperator_EqualTest2()
        {
            // Assign
            SubtractOperator oPerator = new SubtractOperator();
            double x = -10;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(-12));
        }

        [Test]
        public void SubtractOperator_EqualTest3()
        {
            // Assign
            SubtractOperator oPerator = new SubtractOperator();
            double x = 12;
            double y = 2.1;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(9.9));
        }

        [Test]
        public void MultiplyOperator_EqualTest1()
        {
            // Assign
            MultiplyOperator oPerator = new MultiplyOperator();
            double x = 3;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void MultiplyOperator_EqualTest2()
        {
            // Assign
            MultiplyOperator oPerator = new MultiplyOperator();
            double x = -4;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(-8));
        }

        [Test]
        public void MultiplyOperator_EqualTest3()
        {
            // Assign
            MultiplyOperator oPerator = new MultiplyOperator();
            double x = 1.5;
            double y = 7;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(10.5));
        }

        [Test]
        public void DivideOperator_EqualTest1()
        {
            // Assign
            DivideOperator oPerator = new DivideOperator();
            double x = 6;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DivideOperator_EqualTest2()
        {
            // Assign
            DivideOperator oPerator = new DivideOperator();
            double x = -10;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(-5));
        }

        [Test]
        public void DivideOperator_EqualTest3()
        {
            // Assign
            DivideOperator oPerator = new DivideOperator();
            double x = 1.6;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(0.8));
        }

        [Test]
        public void DivideOperator_ThrowExceptionTest()
        {
            // Assign
            DivideOperator oPerator = new DivideOperator();
            double x = 10;
            double y = 0;

            // Act, Assert
            Assert.Throws<DivideByZeroException>(() => oPerator.Compute(x, y));
        }

        [Test]
        public void ExponentiateOperator_EqualTest1()
        {
            // Assign
            ExponentiateOperator oPerator = new ExponentiateOperator();
            double x = 2;
            double y = 3;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void ExponentiateOperator_EqualTest2()
        {
            // Assign
            ExponentiateOperator oPerator = new ExponentiateOperator();
            double x = -2;
            double y = 3;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(-8));
        }

        [Test]
        public void ExponentiateOperator_EqualTest3()
        {
            // Assign
            ExponentiateOperator oPerator = new ExponentiateOperator();
            double x = 0.5;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.That(result, Is.EqualTo(0.25));
        }

        [Test]
        public void CosineFunction_EqualTest1()
        {
            // Assign
            Function function = new CosineFunction();
            double[] paramList = { 0 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]

        public void CosineFunction_EqualTest2()
        {
            // Assign
            Function function = new CosineFunction();
            double[] paramList = { 2.3 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(-0.66627602127982399));
        }

        [Test]
        public void SineFunction_EqualTest1()
        {
            // Assign
            Function function = new SineFunction();
            double[] paramList = { 3.14159265 / 2 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SineFunction_EqualTest2()
        {
            // Assign
            Function function = new SineFunction();
            double[] paramList = { 0 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TangentFunction_EqualTest1()
        {
            // Assign
            Function function = new TangentFunction();
            double[] paramList = { 0 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TangentFunction_EqualTest2()
        {
            // Assign
            Function function = new TangentFunction();
            double[] paramList = { 0.78539816339 };

            // Act
            double result = function.Execute(paramList);

            // Assert
            Assert.That(result, Is.EqualTo(0.99999999998510336));
        }
    }
}