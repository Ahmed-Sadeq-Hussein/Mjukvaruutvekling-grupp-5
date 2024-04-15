using Calculator_project.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.tests
{
    [TestFixture]
    internal class test4
    {
        [Test]
        public void calc_test4()
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator();
            DivideOperator div = new Model.DivideOperator();
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///

            /// we test divisions here . div 0 should give a error and the exception handeling starts us off
            double x = 0;

            try
            {
                x = div.Compute(x, 0);
                Assert.Fail();
            }
            catch (Exception)
            {
                x = 1;
                
            }

            

            Assert.Equals(x, 0.2);

            
        }
    }
}

