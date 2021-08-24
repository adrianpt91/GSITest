using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        public static int Small(int[] numbers)
        {
            HashSet<int> set = new HashSet<int>(); //Collection with int positive numbers
            int index = 1;

            foreach (var n in numbers)
            {
                if (n > 0)
                {
                    set.Add(n); //Store positive numbers
                }
            }

            foreach (var s in set)
            {
                //Check the smallest positive integer (greater than 0) that does not occur in set
                if (set.Contains(index))
                {
                    index++;
                }

            }

            return index;
            
        }
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 3, 6, 4, 1, 2 };
            Console.WriteLine("{0}", Small(numbers));
        }
    }
}
