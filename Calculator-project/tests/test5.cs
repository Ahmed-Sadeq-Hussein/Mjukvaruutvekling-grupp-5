using Calculator_project.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Calculator_project.tests
{
    [TestFixture]
    internal class test5
    {
        [Test]
        public void calc_test10()
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator();
            DivideOperator div = new Model.DivideOperator();
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///

            /// expo
            /// 

            double x = 0;
            x = ex.Compute(x, 0);
            x = ex.Compute(x, 10); // 1
            x += 2;
            x = ex.Compute(x, 2);
            x -= 1;

            x = ex.Compute(x, 3);
            x -= 2;
            x = ex.Compute(x, 0.5);
            x = ex.Compute(x, -1);
            Assert.Equals(x, 0.2);
        }
    }
}