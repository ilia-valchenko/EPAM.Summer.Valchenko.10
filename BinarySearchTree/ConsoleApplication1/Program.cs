using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();

            tree.Add(7);
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);
            tree.Add(7);
            tree.Add(10);

            foreach (var VARIABLE in tree)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("Number of elements: {0}", tree.Count);

            Console.WriteLine("Find element by value {0} is {1}.", 6, tree.FindByValue(6));
            
            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
