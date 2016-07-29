using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Matrix.Tests
{
    public class FactoryClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return
                    new TestCaseData(new SquareMatrix<int>(new int[] {0, 0, 0, 1, 1, 1, 2, 2, 2}),
                                     new SquareMatrix<int>(new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1}),
                                     new SumOfMatricesVisitor<int>((a, b) => a + b),
                                     new SquareMatrix<int>(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }))
                                     .SetName("SumOfTwoSquareMatrices")
                                     .SetDescription("Sum of two square matrix with the same dimensional.");

                yield return
                    new TestCaseData(new SquareMatrix<int>(new int[] {0, 0, 0, 1, 1, 1, 2, 2, 2}),
                        new SquareMatrix<int>(new int[] {1, 1, 1, 1, 1, 1, 1, 1}),
                        new SumOfMatricesVisitor<int>((a, b) => a + b),
                        new SquareMatrix<int>(new int[] {1, 1, 1, 2, 2, 2, 3, 3, 3}))
                        .SetName("SumOfTwoSquareMatricesWithDifferentDimensions")
                        .SetDescription("Sum of two square matrix with the same dimensional.");
            }
        }
    }
}
