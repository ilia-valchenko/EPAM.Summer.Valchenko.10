using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using BinarySearchTree.Tests;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>() {7,5,4,6,1,9,8,10};

            foreach (var VARIABLE in tree.Preorder())
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("\nNumber of tree's elements: " + tree.Count);
            
            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
