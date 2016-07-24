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
            BinaryTree<int> treeInt32 = new BinaryTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };

            //BinaryTree<string> treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };
            var sTree = new BinaryTree<string>();

            var comp = new ComparatorByStringLenght();

            sTree.Add("Hello", comp);
            sTree.Add("Mr", comp);
            sTree.Add("Jon", comp);
            sTree.Add("Skeet", comp);

            //treeInt32.Add(3);
            //treeInt32.Add(12);

            //foreach (var VARIABLE in treeString.Preorder())
            //{
            //    Console.WriteLine(VARIABLE);
            //}


            Console.WriteLine("Print traversal");
            foreach (var VARIABLE in sTree.Preorder())
               {
                   Console.WriteLine(VARIABLE);
               }

                Console.WriteLine("\nResult of finding: {0}", sTree.FindByValue("Bob", comp));

           /* Console.WriteLine("Number of elements: {0}", tree.Count);

            int val = 12;

            if(tree.FindByValue(val) == null)
                Console.WriteLine("\nValue not found!\n");
            else
                Console.WriteLine("\nFind by value {0} result is {1}", val, tree.FindByValue(val));*/
            
            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
