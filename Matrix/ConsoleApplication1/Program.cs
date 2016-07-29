using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var matr1 = new SquareMatrix<int>(new int[] {0, 0, 0, 1, 1, 1, 2, 2, 2});
            var matr1clone = new SquareMatrix<int>(new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 });
            var matr2 = new SquareMatrix<int>(new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1});
            var result = new SquareMatrix<int>(new int[] {1, 1, 1, 2, 2, 2, 3, 3, 3});

            Console.WriteLine("Is equals: {0}", matr1.Equals(matr1clone));

            Console.WriteLine("Is equals SUM: {0}", matr1.Accept(new SumOfMatricesVisitor<int>((a,b) => a+ b), matr2).Equals(result));

           /* yield return
                    new TestCaseData(new SquareMatrix<int>(new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 }),
                                     new SquareMatrix<int>(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                                     new SumOfMatricesVisitor<int>((a, b) => a + b))
                                     .Returns(new SquareMatrix<int>(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }))
                                     .SetName("SumOfTwoSquareMatrices")
                                     .SetDescription("Sum of two square matrix with the same dimensional.");*/

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
