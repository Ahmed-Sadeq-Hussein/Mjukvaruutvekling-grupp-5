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
    internal class test6
    {
        [Test]
        public void calc_test6()
        {
            Controller.Controller c = new Controller.Controller();
            bool x = true;

            if (c.CalculateExpression("1+1") == "2")
            {
                x = false;
            }

            if (c.CalculateExpression("1-1") == "0")
            {
                x = false;
            }

            if (c.CalculateExpression("1*1") == "1")
            {
                x = false;
            }

            if (c.CalculateExpression("1*10") == "10")
            {
                x = false;
            }


            if (c.CalculateExpression("3^1") == "3")
            {
                x = false;
            }
           //success

            if (x)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            

        }
    }
}
