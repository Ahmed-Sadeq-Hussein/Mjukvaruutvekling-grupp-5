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
    internal class test10
    {
        [Test]
        public void calc_test10 () 
        {
            ///
            SumOperator add = new Model.SumOperator();
            SubtractOperator neg = new Model.SubtractOperator();
            ExponentiateOperator ex = new Model.ExponentiateOperator();
            DivideOperator div = new Model.DivideOperator();
            MultiplyOperator multiply = new Model.MultiplyOperator();
            ///
        }
    }
}
