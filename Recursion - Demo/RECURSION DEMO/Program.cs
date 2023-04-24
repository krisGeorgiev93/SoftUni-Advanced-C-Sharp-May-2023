using System;

namespace RECURSION_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3 };

            Console.WriteLine(Sum(array, 0)); 

            static int Sum(int [] array, int index)
            {
                if (index == array.Length)
                {
                    return 0;
                }

                Console.WriteLine("Before entering recursive method");
                int currentSum = array[index] + Sum(array, index + 1);
                Console.WriteLine(currentSum);
                Console.WriteLine("After entering recursive method");

                return currentSum;

            }
        }
    }
}
