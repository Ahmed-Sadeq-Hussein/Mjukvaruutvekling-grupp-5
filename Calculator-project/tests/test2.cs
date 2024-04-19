using Calculator_project.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Model;
using NUnit.Framework;
namespace Calculator_project.tests
{using NUnit.Framework;
    [TestFixture]
    internal class test2
    {
        [Test]
        public void calc_testing2()
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator();
            DivideOperator div = new Model.DivideOperator();
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///

            double x = 1000;

            // testing subtracting 0, 1, 10 , 100 and sub 1 . also subtract negatives
            x = neg.Compute(x, 1);
            x = neg.Compute(x, 0);
            x = neg.Compute(x, 10);
            x = neg.Compute(x, 100);
            x = neg.Compute(x, 5.2);
            x = neg.Compute(x, -5);
            // should be 888.8

            Assert.Equals(888.8, x);

        }
    }
}
