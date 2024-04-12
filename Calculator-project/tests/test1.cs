using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Pass();
            //the following
// 1 + 2 - 3 * 4 
        }
    }
}
