using System;

namespace Exercise2
{
    class Program
    {
        public static int FindSmallest(int[] numbers)
        {
            int small = numbers[0]; //taking into account the first array value
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < small)
                {
                    small = numbers[i];
                }
            }

            return small;
        }
        static void Main(string[] args)
        {
            var numbers = new int[] { -1, 1, -2, 2 };
            Console.WriteLine("{0}", FindSmallest(numbers));
        }
    }
}
