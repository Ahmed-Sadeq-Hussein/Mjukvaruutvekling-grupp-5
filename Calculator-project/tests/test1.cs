using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Model;
using Calculator_project.Model;
using NUnit.Framework;
namespace Calculator_project.tests
{
    /// <summary>
    /// Here we try to test normal calculations and test casual every day operations.
    /// no need for edge casss.
    ///  <3
    /// </summary>
    //
    [TestFixture]
    internal class test1
    {
        [Test]
       public void cal_testing1 ()
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator(); 
            DivideOperator div = new Model.DivideOperator();    
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///

            ///testing the following. Adding negatives. adding 0, adding 10 , 100 . adding digits numbers.
            double x = add.Compute(-12 , -10);

            x += add.Compute(0, 1);
            x += add.Compute(10 , 110);
            x += add.Compute(22.22, 1.11);

            Assert.Equals(122.33 , x);
            

        }
    }
}
