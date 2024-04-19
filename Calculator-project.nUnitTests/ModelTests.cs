using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Calculator_project.Model;

namespace Calculator_project.nUnitTests
{
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
            double result = oPerator.Compute(x,y);

            // Assert
            Assert.AreEqual(3, result);
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
            Assert.AreEqual(1, result);
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
            Assert.AreEqual(3.923, result);
        }

        [Test]
        public void SubtractOperator_EqualTest()
        {
            // Assign
            SubtractOperator oPerator = new SubtractOperator();
            double x = 1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x,y);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void MultiplyOperator_EqualTest()
        {
            // Assign
            MultiplyOperator oPerator = new MultiplyOperator();
            double x = 1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x,y);

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivideOperator_EqualTest()
        {
            // Assign
            DivideOperator oPerator = new DivideOperator();
            double x = 1;
            double y = 2;

            // Act
            double result = oPerator.Compute(x, y);

            // Assert
            Assert.AreEqual(0.5, result);
        }

        [Test]
        public void ExponentiateOperator_EqualTest()
        {
            // Assign
            ExponentiateOperator oPerator = new ExponentiateOperator();
            double x = 1;
            double y = 2;
                
            // Act
            double result = oPerator.Compute(x,y);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
