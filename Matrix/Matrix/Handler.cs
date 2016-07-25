using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Handler
    {
        public void Message<T>(int i ,int j, T value)
        {
            Console.WriteLine($"Element [{i}][{j}] was changed. New value is {value}.");
        }
    }
}
