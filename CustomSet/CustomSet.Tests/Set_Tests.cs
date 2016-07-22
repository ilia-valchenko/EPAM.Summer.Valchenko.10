using System;
using NUnit.Framework;

namespace CustomSet.Tests
{
    [TestFixture]
    public class Set_Tests
    {
        private Point[] array1 = 
        {
            new Point(1,1),
            new Point(2,2),
            new Point(3,3),
            new Point(5,5)
        };

        private Point[] array2 =
        {
            new Point(3,3),
            new Point(5,5),
            new Point(9,9),
            new Point(10,10)
        };

        [TestCase(TestName = "CreateInt32Queue")]
        public void TestMethod1()
        {

        }
    }
}
