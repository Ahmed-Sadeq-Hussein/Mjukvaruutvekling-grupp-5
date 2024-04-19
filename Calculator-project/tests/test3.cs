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
    internal class test3
    {
        [Test]
        public void calc_test3()
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator();
            DivideOperator div = new Model.DivideOperator();
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///
            // testing the multiply operator 
            double x = 1;

            //sets to 0. Test then 2, 10 , 100 , .001 and finally a number such as 11.11
            x = multiply.Compute(x, 0);
            x += 1;
            x = multiply.Compute(x, 2);
            x = multiply.Compute(x, 10);
            x = multiply.Compute(x, 100);
            x = multiply.Compute(x, 0.001);
            x = multiply.Compute(x, 11.11);

            Assert.Equals(22.22, x);

        }
    }
}
