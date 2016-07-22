using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using CustomSet;

namespace CustomSet.Tests
{
    [TestFixture]
    public class Set_Tests
    {
        private Set<Point> firstSet = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5)});
        private Set<Point> secondSet = new Set<Point>(new Point[] { new Point(3, 3), new Point(5, 5), new Point(9, 9), new Point(10, 10) });

        [TestCase(TestName = "AddUniqueElementToSet")]
        public void AddUniqueElementToSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5), new Point(100, 200) });
            var newPoint = new Point(100, 200);

            firstSet.Add(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestCase(TestName = "AddExistingElement")]
        public void AddExistingElementToSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5)});
            var newPoint = new Point(5, 5);

            firstSet.Add(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestCase(TestName = "DeleteExistingElement")]
        public void DeleteExistingElementFromSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3)});
            var newPoint = new Point(5, 5);

            firstSet.Delete(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestCase(TestName = "DeleteNonExistingElementFromSet", ExpectedException = typeof(ArgumentException))]
        public void DeleteNonExistingElementFromSet()
        {
            var newPoint = new Point(5, 5);
            firstSet.Delete(newPoint);
        }

        [TestCase(TestName = "DeleteNullFromSet", ExpectedException = typeof(ArgumentNullException))]
        public void DeleteNullFromSet()
        {
            firstSet.Delete(null);
        }

        [TestCase(TestName = "IntersectionOfTwoSets")]
        public void IntersectionOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] {new Point(3, 3), new Point(5, 5)});

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.Intersect(secondSet)));
        }

        [TestCase(TestName = "DifferenceOfTwoSets")]
        public void DifferenceOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2) });

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.Difference(secondSet)));
        }

        [TestCase(TestName = "UnionOfTwoSets")]
        public void UnionOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3,3), new Point(5,5), new Point(9,9), new Point(10,10)});

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.Union(secondSet)));
        }

        [TestCase(TestName = "SymmetricDifferenceOfTwoSets")]
        public void SymmetricDefferenceOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(9, 9), new Point(10, 10) });

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.SymmetricDifference(secondSet)));
        }
    }
}
