using System;
using NUnit.Framework;

namespace Matrix.Tests
{
    [TestFixture]
    public class Matrix_Tests
    {
        [Test, TestCaseSource(typeof(FactoryClass), "TestCases")]
        public void TestSumOfInt32Matrices(Matrix<int> A, Matrix<int> B, MatrixVisitor<int> visitor, Matrix<int> Result)
        {
            Assert.IsTrue(A.Accept(visitor, B).Equals(Result));
        }
    }
}
