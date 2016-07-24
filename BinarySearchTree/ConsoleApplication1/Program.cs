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
            var tree = new BinaryTree<int>() {7,5,4,6,1,8,7,10};

            foreach (var VARIABLE in tree.Inorder())
            {
                Console.WriteLine(VARIABLE);
            }

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
