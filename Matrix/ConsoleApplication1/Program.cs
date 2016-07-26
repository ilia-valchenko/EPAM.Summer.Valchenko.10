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
            int[][] arr = new int[3][];
            arr[0] = new int[] {1, 3, 0};
            arr[1] = new int[] {3, 2, 6};
            arr[2] = new int[] {0, 6, 5};

            var sym = new SymmetrixMatrix<int>(arr);

            /*Console.WriteLine("Diagonal matrix:");
            for (int i = 0; i < sym.Size; i++)
            {
                for(int j = 0; j < sym.triangleArray[i].Length; j++)
                    Console.Write(sym.triangleArray[i][j] + " ");

                Console.Write(Environment.NewLine);
            }*/


            Console.WriteLine("Get above:" + sym.GetValue(2,2));

            foreach (var VARIABLE in sym)
            {
                Console.Write(VARIABLE + " ");
            }


            /////////////////////////////////////////////////////
            /// 
            var mtx = new SquareMatrix<int>(new int[] {1,3,0,3,2,6,0,6,5});

            var visitor = new ConcreteVisitor<int>();

            var res = mtx.Accept(visitor, mtx);

            Console.WriteLine("Result of adition:");
            foreach (var VARIABLE in res)
            {
                Console.Write(VARIABLE + " ");
            }
            
            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
